namespace PropertyInvestAuction.Server.Infrastructure
{
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using PropertyInvestAuction.Data;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Data;

    public static class ServiceCollectoionExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettings = GetAppSettings(services, configuration);

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true,
                    };
                });

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt =>
                        {
                            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                        });
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }

        private static AppSettings GetAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppSettings>();
        }
    }
}
