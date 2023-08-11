using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API
{
    public static class DependencyInjection
    {
          public static IServiceCollection AddPresentation(this IServiceCollection services){
            
            // Add services to the container.
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            return services;
        }

    }
}