using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCV.Infrastructure.Persistence;
using MyCV.Application.Data;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using MyCV.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyCV.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration ){
            services.AddPersistence(configuration);
            return services;
        }
        
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerDataBase")));    
            services.AddScoped<IApplicationDBContext>(provider => provider.GetRequiredService<ApplicationDBContext>());
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDBContext>());
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            return services;
        }
    }
}