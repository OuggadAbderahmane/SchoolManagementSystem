using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration Configuration)
        {
            #region Identity
            services.AddIdentity<User, Role>(option =>
            {

                // Password Setting
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 8;
                option.Password.RequiredUniqueChars = 1;

                // Lockout Setting
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User Setting
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-._@+";
                option.User.RequireUniqueEmail = false;

                // SignIn Setting
                option.SignIn.RequireConfirmedEmail = false;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            #endregion

            #region Authentication
            //var jwtOptions = Configuration.GetSection("Jwt").Get<JwtOptions>();
            //services.AddSingleton(jwtOptions!);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            //    {
            //        //options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = jwtOptions!.Issuer,
            //            ValidateAudience = true,
            //            ValidAudience = jwtOptions.Audience,
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
            //        };
            //    });
            #endregion

            #region Authorization
            //services.AddAuthorization(option =>
            //{
            //    option.AddPolicy("CreateStudent", policy =>
            //    {
            //        policy.RequireClaim("Create Student", "true");
            //    });
            //    option.AddPolicy("EditStudent", policy =>
            //    {
            //        policy.RequireClaim("Edit Student", "true");
            //    });
            //    option.AddPolicy("DeleteStudent", policy =>
            //    {
            //        policy.RequireClaim("Delete Student", "true");
            //    });
            //});
            #endregion

            return services;
        }
    }
}
