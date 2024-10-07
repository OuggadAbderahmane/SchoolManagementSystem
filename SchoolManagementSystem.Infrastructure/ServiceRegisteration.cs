using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Helper;
using SchoolManagementSystem.Infrastructure.Data;
using System.Reflection;
using System.Text;

namespace SchoolManagementSystem.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration Configuration)
        {

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization : `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        In = ParameterLocation.Header,
                        Name = "Bearer"
                    },new string[] {}
                    }
                });
            });

            #endregion

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
            var jwtOptions = Configuration.GetSection("Jwt").Get<JwtOptions>();
            services.AddSingleton(jwtOptions!);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    //options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
                    };
                });
            #endregion

            #region Authorization
            services.AddAuthorization(option =>
            {
                option.AddPolicy("StudentOnly", policy =>
                {
                    policy.RequireClaim("UserType", "Student");
                });
                option.AddPolicy("TeacherOnly", policy =>
                {
                    policy.RequireClaim("UserType", "Teacher");
                });
                option.AddPolicy("GuardianOnly", policy =>
                {
                    policy.RequireClaim("UserType", "Guardian");
                });
            });
            #endregion

            return services;
        }
    }
}
