using CarRental.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Web.Configuration
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var dbInitializer = serviceScope.ServiceProvider.GetService<IApplicationDbInitializer>();

            if (dbInitializer != null)
            {
                dbInitializer.Migrate().GetAwaiter().GetResult();
                dbInitializer.Seed().GetAwaiter().GetResult();
            }

            return app;
        }
    }
}