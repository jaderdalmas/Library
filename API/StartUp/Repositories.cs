using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;

namespace Api.StartUp
{
    /// <summary>
    /// Api Repositories
    /// </summary>
    public static class Repositories
    {
        /// <summary>
        /// Repositories Register
        /// </summary>
        /// <param name="services">Api Services</param>
        public static void Register(IServiceCollection services)
        {
            // services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Service
            services.AddScoped(typeof(IBookService), typeof(BookService));

            // Repository
            services.AddScoped(typeof(ISqlBookRepository), typeof(SqlBookRepository));
            services.AddScoped(typeof(IKotlinLangRepository), typeof(KotlinLangRepository));
        }

        //private static UserInfo GetUserInfo(IServiceProvider provider)
        //{
        //    var context = provider.GetService<IHttpContextAccessor>();
        //    return new UserInfo(context.HttpContext.User.FindFirstValue(Authentication.Name).Split('@')[1],
        //        context.HttpContext.User.FindFirstValue(Authentication.UserId));
        //}
    }
}
