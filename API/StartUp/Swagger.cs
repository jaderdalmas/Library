using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Api.StartUp
{
    /// <summary>
    /// Api Swagger
    /// </summary>
    public static class Swagger
    {
        /// <summary>
        /// Register swagger
        /// </summary>
        /// <param name="services">Service collection</param>
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sebo API", Version = "v1" });

                //Show Authorize
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() }, });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Api.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="app">App builder</param>
        /// <param name="env">API Environment</param>
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env = null)
        {
            if (env != null && env.IsProduction())
                return;

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sebo API V1");
            });
        }
    }
}
