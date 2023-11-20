

using BootRent.BL.Managers.AppUsers;
using BootRent.BL.Managers.Boos;
using BootRent.BL.Managers.Reservations;
using BootRent.BL.Services.MailingService;
using BootRent.DAL.Data.Context.Identity;
using BootRent.DAL.Data.Context.Rent;
using BootRent.DAL.Data.Models.Identity;
using BootRent.DAL.Repo;
using BootRent.DAL.Repo.Boots;
using BootRent.DAL.Repo.Reservations;
using BootRent.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace BootRentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));




            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                . AddDefaultTokenProviders();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "default";
                options.DefaultScheme = "default";
            }).
                AddJwtBearer("default", options =>
                {
                    //GenerateKey

                    var secretKey = builder.Configuration.GetValue<string>("SecretKey");
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                    var Key = new SymmetricSecurityKey(secretKeyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        IssuerSigningKey = Key

                    };
                    });

            builder.Services.AddDbContext<RentContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("RentConnection")));


            builder.Services.AddScoped<IBootRepo, BootRepo>();
            builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.Configure<MailingSettings>(builder.Configuration.GetSection("MailSetting"));
            builder.Services.AddTransient<IMailingService, MailingService>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();





            builder.Services.AddScoped<IBootManager, BootManager>();
            builder.Services.AddScoped<IReservationManager, ReservationManager>();
            builder.Services.AddScoped<IUserManager, UserManager>();







            var app = builder.Build();

                    // Configure the HTTP request pipeline.
                    if (app.Environment.IsDevelopment())
                    {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                    }

                    app.UseHttpsRedirection();


                    app.UseAuthentication();
                    app.UseAuthorization();


                    app.MapControllers();

                    app.Run();



                }
                }
    }
    
