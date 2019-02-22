using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Api.StartUp
{
    /// <summary>
    /// Api Cors
    /// </summary>
    public class Cors
    {
        /// <summary>
        /// Cors Policy
        /// </summary>
        public const string Policy = "CorsPolicy";

        /// <summary>
        /// Cors Register
        /// </summary>
        /// <param name="configuration">Api Configuration</param>
        /// <param name="services">Api Services</param>
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            var Link = configuration.GetConnectionString("ListoWebSite");
            services.AddCors(options =>
            {
                options.AddPolicy(Policy, builder => builder.WithOrigins(Link.Split(';'))
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials()
                    .WithExposedHeaders(new List<string>() { "X-Pagination", "X-Summary", "Content-Disposition" }.ToArray()));
            });
        }
    }
}
