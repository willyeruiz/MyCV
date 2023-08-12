using Microsoft.EntityFrameworkCore;
using MyCV.Infrastructure.Persistence;

namespace MyCV.API.Extentions
{
    public static class MigrationExtentions
    {
        public static void ApplyMigrations(this WebApplication app){
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            dbContext.Database.Migrate();
        }
    }
}