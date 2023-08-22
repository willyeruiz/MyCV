using MyCV.API.Middlewares;

namespace MyCV.API
{
    public static class DependencyInjection
    {
          public static IServiceCollection AddPresentation(this IServiceCollection services){
            
            services.AddCors();
            // Add services to the container.
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            return services;
        }

    }
}