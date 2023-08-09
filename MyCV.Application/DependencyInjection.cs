using Microsoft.Extensions.DependencyInjection; 
using MediatR;
using FluentValidation;

namespace MyCV.Application{

    public static class DependencyInjection
     {
        

        public static IServiceCollection AddApplication(this IServiceCollection services){
            
            services.AddMediatR( config => {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
             
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

            return services;
        }

     }

}
