﻿using Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using Services.Mapping;
using Services.Core;
using Microsoft.AspNetCore.Identity;
using Data.Entities;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Services.Hubs;
using Newtonsoft.Json.Converters;




using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.Text;

namespace ScheduleManagementSession01.Extensions
{
    public static class StartupExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });
        }
        public static void ApplyPendingMigrations(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<AppDbContext>();
          if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddBussinessService(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExerciseDetailService, ExerciseDetailService>();
            services.AddScoped<IPhysiotherapistService, PhysiotherapistService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ITypeOfSlotService, TypeOfSlotService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IBookingDetailService, BookingDetailService>();
            services.AddScoped<IBookingScheduleService, BookingScheduleService>();
            services.AddScoped<IExerciseResourceService, ExerciseResourceService>();
            services.AddScoped<ISubProfileService, SubProfileService>();
            services.AddScoped<IFavoriteExerciseService, FavoriteExerciseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRelationshipService, RelationshipService>();
            services.AddScoped<IProblemService, ProblemService>();


            //add notification service
            services.AddSingleton<INotificationHub, NotificationHub>();
            services.AddScoped<INotificationService, NotificationService>();

        }
        public static void ConfigIdentityService(this IServiceCollection services)
        {
            var build = services.AddIdentityCore<User>(option =>
            {
                option.SignIn.RequireConfirmedAccount = false;
                option.User.RequireUniqueEmail = false;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;

                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedAccount = false;
            }); build.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            build.AddSignInManager<SignInManager<User>>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddDefaultTokenProviders();
            services.AddAuthorization();


        }
        public static void AddJWTAuthentication(this IServiceCollection services, string key, string issuer)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtconfig =>
                {
                    jwtconfig.SaveToken = true;
                    jwtconfig.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidateAudience = false,
                        ValidIssuer = issuer,
                        ValidateIssuer = true,
                        ValidateLifetime = false,
                        RequireAudience = false,
                    };
                    jwtconfig.Events = new JwtBearerEvents()
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            // Ensure we always have an error and error description.
                            if (string.IsNullOrEmpty(context.Error))
                                context.Error = "invalid_token";
                            if (string.IsNullOrEmpty(context.ErrorDescription))
                                context.ErrorDescription = "This request requires a valid JWT access token to be provided";

                            // Add some extra context for expired tokens.
                            if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                                context.Response.Headers.Add("x-token-expired", authenticationException.Expires.ToString("o"));
                                context.ErrorDescription = $"The token expired on {authenticationException.Expires.ToString("o")}";
                            }

                            return context.Response.WriteAsync(JsonSerializer.Serialize(new
                            {
                                error = context.Error,
                                error_description = context.ErrorDescription
                            }));
                        },
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (path.StartsWithSegments("/notificationHub"))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            /*services.AddAuthentication().AddTwoFactorRememberMeCookie();
            services.AddAuthentication().AddTwoFactorUserIdCookie();*/
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HealthCareAndHealing",
                    Version = "v2.0.0",
                    Description = "HealthCareAndHealing management system",
                });
                c.UseInlineDefinitionsForEnums();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Add EarnPoints Bearer Token Here",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer"
                    },
                    new List<string>()
                }
            });
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
