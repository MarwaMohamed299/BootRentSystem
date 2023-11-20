using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BootRent.DAL;
using BootRent.DAL.Data.Models.Identity;
using BootRent.BL.Dtos.Identity;
using BootRent.DAL.Response;
using System.Security.Cryptography;
using BootRent.DAL.Data.Context.Identity;
using Microsoft.EntityFrameworkCore;
using BootRent.DAL.Repo;
using BootRent.BL.Services.MailingService;
using BootRent.BL.Managers.AppUsers;

namespace BootRentSystem.Controllers.AppUsers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppIdentityDbContext _appUserDbContext;
        private readonly IUserRepo _userRepo;
        private readonly IMailingService _mailingService;
        private readonly IUserManager _userManager1;

        public AppUsersController(IConfiguration configuration, UserManager<AppUser> userManager,IUserManager userManager1, AppIdentityDbContext appUserDbContext, IMailingService mailService,IUserRepo userRepo)
        {
            _configuration = configuration;
            _userManager = userManager;
            _appUserDbContext = appUserDbContext;
            _userRepo = userRepo;
            _mailingService = mailService;
            _userManager1 = userManager1;
        }




        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserManagerResponse>> Register(RegisterDto registerDto)
        {
            var newAppUser = new AppUser
            {
                UserName = registerDto.UserName,
                UserType = registerDto.UserType,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                City = registerDto.City,
                Street = registerDto.Street,
                State = registerDto.State,
                Email = registerDto.Email



            };
            var RegisterResult = await _userManager.CreateAsync(newAppUser, registerDto.PasswordHash);

            if (!RegisterResult.Succeeded)
            {
                foreach (var error in RegisterResult.Errors)
                {
                    return BadRequest(RegisterResult.Errors);
                }

                return BadRequest("Registration Failed");


            }
            else
            {
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,  newAppUser.DisplayName),
                    new Claim(ClaimTypes.Email,  newAppUser.Email),
                    new Claim (ClaimTypes.Role ,newAppUser.UserType.ToString())
                };
                await _userManager.AddClaimsAsync(newAppUser, userClaims);
                return new UserManagerResponse()
                {
                    Message = "Registeration  is Successful ",
                    IsSuccess = true
                };
            }



        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LogInResultDto>> LogIn(LogInDto credentials)
        {
            var appUser = await _userManager.FindByEmailAsync(credentials.Email);
            if (appUser == null)
            {
                return BadRequest("User Not Found");
            }

            if (await _userManager.IsLockedOutAsync(appUser))
            {
                return BadRequest("Try Again");
            }

            bool IsAuthenticated = await _userManager.CheckPasswordAsync(appUser, credentials.PasswordHash);
            if (!IsAuthenticated)
            {
                await _userManager.AccessFailedAsync(appUser);
                return Unauthorized("Wrong Credentials");
            }


            var secretKey = _configuration.GetValue<string>("SecretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(secretKeyInBytes);
            var generatingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var userClaims = await _userManager.GetClaimsAsync(appUser);
            var jwt = new JwtSecurityToken
                (
                    claims: userClaims,
                    notBefore: DateTime.Now,
                    issuer: "BackendTeam",
                    audience: "appUsers",
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: generatingToken
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(jwt);

            return new LogInResultDto
            {
                Token = tokenString,
                ExpiryDate = DateTime.Now.AddMinutes(15),
                IsSuccess = true,
                Message = "LogIn Successful"
            };


        }
        [HttpPost]
        [Route("ForgetPassword")]

        public async Task<ActionResult<UserManagerResponse>> ForgetPassword(ForgetPasswordDto forgetPasswordDto)
        {
            try
            {
                //check entered email is valid 
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(forgetPasswordDto.Email);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid email address format.");
                }

                


                var AppUser = await _appUserDbContext.appUsers.FirstOrDefaultAsync(X => X.Email == forgetPasswordDto.Email);
              
                //Check user email is exist 
                if (AppUser == null)
                    return new UserManagerResponse
                    {
                        Message = "This Email Does not Exist",
                        IsSuccess = false
                    };
                //Generate OTP
                var random = new Random();
                var OTP = random.Next(1000, 9999);
                var otpGenerationTime = DateTime.Now;
                //SendEmailWithOTP

                var EmailToBeSent = await _mailingService.SendEmail(forgetPasswordDto.Email, OTP);

                ////Check if OTP is Valid
                //var Time = DateTime.Now - otpGenerationTime;
                //if (Time.TotalMinutes > 10)
                //{
                //    return new UserManagerResponse
                //    {
                //        Message = "OTP has expired. Please request a new one.",
                //        IsSuccess = false
                //    };

                //}
                return new UserManagerResponse
                {
                    Message = "EmailWith OTP is Sent Please Use It to reset Your Password",
                    IsSuccess = true
                };


            }
            catch (Exception ex)
            {
                // Return an error response in case of an exception
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };

            }

        }


        [HttpPost]
        [Route("Confirm-Email")]
        public async Task<ActionResult<UserManagerResponse>> ConfirmEmail( int otp)
        {
            try
            {
                var ValidatedOTP = await _userRepo.RetrieveEmailWithOTP(otp);

                if (ValidatedOTP == -1)
                {
                    return new UserManagerResponse
                    {
                        Message = "Invalid OTP or OTP has expired. Please request a new one.",
                        IsSuccess = false
                    };
                }
                if (ValidatedOTP == otp)
                {
                    return new UserManagerResponse
                    {
                        Message = "Validated OTP",
                        IsSuccess = true
                    };
                }
                return new UserManagerResponse
                {
                    Message = "Unexpected condition occurred.",
                    IsSuccess = false
                };
            }
            
            catch (Exception ex)
            {
                // Return an error response in case of an exception
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }




        }


    }


