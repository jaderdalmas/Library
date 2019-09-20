using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace UnitTest.Repository.MockTest
{
    public class DependencyInjection
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="services">Services</param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IKotlinLangRepository, KotlinLangRepositoryMockTest>();
            services.AddScoped<ISqlBookRepository, SqlBookRepositoryMockTest>();
        }
    }
}
