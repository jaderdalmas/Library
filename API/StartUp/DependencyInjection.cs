using Microsoft.Extensions.DependencyInjection;

namespace Api.StartUp
{
    /// <summary>
    /// Api Repositories
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Repositories Register
        /// </summary>
        /// <param name="services">Api Services</param>
        public static void Register(IServiceCollection services)
        {
            // services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUserInfo>(provider => GetUserInfo(provider));
            //services.AddScoped(typeof(INotification), typeof(NotificationProvider));

            Service.DependencyInjection.Register(services);
            Repository.DependencyInjection.Register(services);
        }

        //private static UserInfo GetUserInfo(IServiceProvider provider)
        //{
        //    var context = provider.GetService<IHttpContextAccessor>();
        //    return new UserInfo(context.HttpContext.User.FindFirstValue(Authentication.Name),
        //        context.HttpContext.User.FindFirstValue(Authentication.UserId));
        //}
    }
}