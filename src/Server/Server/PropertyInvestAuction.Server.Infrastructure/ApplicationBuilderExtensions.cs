namespace PropertyInvestAuction.Server.Infrastructure
{
    using System.Linq;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using PropertyInvestAuction.Data;

    using static PropertyInvestAuction.Common.GlobalConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddCors(this IApplicationBuilder app)
            => app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyMethod();
                opt.AllowAnyHeader();
            });

        public static IApplicationBuilder AddSwaggerUi(this IApplicationBuilder app) 
            => app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Property Invest Auction API V1");
                c.RoutePrefix = string.Empty;
            });

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();

            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.Add(new Data.Models.AppRole { Name = AdministratorRoleName });
                dbContext.Roles.Add(new Data.Models.AppRole { Name = ClientRoleName });
            }

            return app;
        }
    }
}
