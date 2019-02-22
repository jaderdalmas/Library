using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Api.StartUp
{
    /// <summary>
    /// Api Localization
    /// </summary>
    public static class Localization
    {
        /// <summary>
        /// Configure Localization
        /// </summary>
        /// <param name="app">App builder</param>
        public static void Configure(IApplicationBuilder app)
        {
            var standardCulture = CultureInfo.InvariantCulture;

            var supportedCultures = new[] { standardCulture };
            var localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(standardCulture)
            };

            app.UseRequestLocalization(localizationOptions);
        }
    }
}
