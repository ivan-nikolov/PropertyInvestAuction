using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using PropertyInvestAuction.Data;

namespace PropertyInvestAuction.Server.Infrastructure
{
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

            return app;
        }
    }
}
