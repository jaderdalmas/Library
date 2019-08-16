using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace Api.StartUp
{
    /// <summary>
    /// Compressão de dados
    /// </summary>
    public static class Compression
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="services">Services</param>
        public static void Register(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            }); 
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">Application</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();
        }
    }
}
