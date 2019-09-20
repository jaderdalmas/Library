using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public class DependencyInjection
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="services">Services</param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(ISqlBookRepository), typeof(SqlBookRepository));
            services.AddScoped(typeof(IKotlinLangRepository), typeof(KotlinLangRepository));
        }
    }
}
