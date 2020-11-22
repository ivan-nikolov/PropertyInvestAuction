namespace PropertyInvestAuction.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Identity;
    using PropertyInvestAuction.Services.Mapping;

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
                .AddJwtAuthentication(this.Configuration)
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

            AutoMapperConfig.RegisterMappings(typeof(LoginInputModel).Assembly);

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
