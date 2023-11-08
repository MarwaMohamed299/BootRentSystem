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

namespace BootRentSystem.Controllers.AppUsers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AppUsersController(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

     

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(RegisterDto registerDto)
        {
            var newAppUser = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                UserType = registerDto.UserType,

                Address = new Address
                {
                    FirstName = registerDto.FName,
                    LastName = registerDto.LName,
                    City = registerDto.City,
                    Street = registerDto.Street,
                    State = registerDto.State,
                }

            };
            var RegisterResult = await _userManager.CreateAsync(newAppUser, registerDto.Password);

            if (!RegisterResult.Succeeded)
            {
                foreach (var error in RegisterResult.Errors)
                {
                    // Log or debug the error messages
                    Console.WriteLine($"Error: {error.Description}");
                }

                return BadRequest("Registration Failed");


            }
            else
            {
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,  newAppUser.DisplayName),
                    new Claim(ClaimTypes.Email,  newAppUser.Email),
                    new Claim("Nationality", "Egyptian"),
                    new Claim (ClaimTypes.Role ,newAppUser.UserType.ToString())
                };
                await _userManager.AddClaimsAsync(newAppUser, userClaims);
                return null;
            }



        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LogInResultDto>> LogIn(LogInDto credentials)
        {
            var appUser = await _userManager.FindByNameAsync(credentials.DisplayName);
            if (appUser == null)
            {
                return BadRequest("User Not Found");
            }
             
            if (await _userManager.IsLockedOutAsync(appUser))
            {
                return BadRequest("Try Again");
            }

            bool IsAuthenticated = await _userManager.CheckPasswordAsync(appUser, credentials.Password);
            if (! IsAuthenticated)
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
                Message = "LogIn Success"
            };

            
        }
    }
}
