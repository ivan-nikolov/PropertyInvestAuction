namespace PropertyInvestAuction.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Identity;
    using PropertyInvestAuction.Services;
    using PropertyInvestAuction.Services.Data;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models.Identity;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .RegisterAppServices()
                .AddServices(typeof(IIdentityService).Assembly, typeof(ICloudinaryService).Assembly)
                .AddJwtAuthentication(this.Configuration)
                .AddCloudinary(this.Configuration)
                .AddSwagger()
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            AutoMapperConfig.RegisterMappings(typeof(LoginInputModel).Assembly, typeof(UserServiceModel).Assembly);

            app
            .ApplyMigrations()
            .UseSwagger()
            .AddSwaggerUi()
            .UseRouting()
            .AddCors()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
