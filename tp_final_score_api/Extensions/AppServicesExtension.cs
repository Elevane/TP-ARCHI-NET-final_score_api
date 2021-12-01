using System.Reflection;
using tp_final_score_api.Repositories;
using tp_final_score_api.Repositories.Interfaces;
namespace tp_final_score_api.Extensions
{
    public static class AppServicesExtension
    {

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IScoreRepository, ScoreRepository>();
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
