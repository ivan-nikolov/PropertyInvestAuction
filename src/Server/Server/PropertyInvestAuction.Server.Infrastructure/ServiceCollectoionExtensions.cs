namespace PropertyInvestAuction.Server.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using CloudinaryDotNet;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    using PropertyInvestAuction.Common.ServiceTypes;
    using PropertyInvestAuction.Data;
    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Data.Repositories;

    public static class ServiceCollectoionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var mapList = GetServices(assemblies);

            foreach (var map in mapList)
            {
                var service = map.Service;
                var instance = map.Implementation;
                if (typeof(ITransient).IsAssignableFrom(service))
                {
                    services.AddTransient(service, instance);
                }
                else if (typeof(IScoped).IsAssignableFrom(service))
                {
                    services.AddScoped(service, instance);
                }
                else if (typeof(ISingleton).IsAssignableFrom(service))
                {
                    services.AddSingleton(service, instance);
                }
            }

            return services;
        }

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
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            return services;
        }

        public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            var name = configuration["Cloudinary:Name"];
            Account account = new Account(
                configuration["Cloudinary:Name"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);
            services.AddSingleton(cloudinary);

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Propery Invest Auction API",
                    
                    Contact = new OpenApiContact
                    {
                        Name = "Ivan Iliev",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/ivan-nikolov"),
                    }
                });
            });

        private static AppSettings GetAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppSettings>();
        }

        private static List<TypeMap> GetServices(params Assembly[] assemblies)
        {
            var servicesList = new List<TypeMap>();
            foreach (var assembly in assemblies)
            {
                var services = assembly.DefinedTypes
                    .Where(t => t.ImplementedInterfaces
                        .Any(i => i.Equals(typeof(ITransient))
                            || i.Equals(typeof(IScoped))
                            || i.Equals(typeof(ISingleton)))
                        && t.IsClass
                        && !t.IsAbstract)
                    .Select(t => new TypeMap 
                    { 
                        Implementation = t,
                        Service = t.ImplementedInterfaces.FirstOrDefault(i => 
                            (typeof(ITransient).IsAssignableFrom(i)
                            || typeof(IScoped).IsAssignableFrom(i)
                            || typeof(ISingleton).IsAssignableFrom(i)) 
                            && i.GetInterfaces().Any(ii => ii == typeof(ITransient)
                                || ii == typeof(IScoped)
                                || ii == typeof(ISingleton)))
                    })
                    .Where(t => t.Service != null);

                servicesList.AddRange(services);
            }

            return servicesList;
        }

        private class TypeMap
        {
            public Type Implementation { get; set; }

            public Type Service { get; set; }

            public Type[] Services { get; set; }
        }
    }
}
