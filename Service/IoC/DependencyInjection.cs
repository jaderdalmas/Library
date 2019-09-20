using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public class DependencyInjection
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="services">Services</param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }
    }
}
