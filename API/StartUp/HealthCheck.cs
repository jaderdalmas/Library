using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Mime;

namespace Api.StartUp
{
    /// <summary>
    /// Health Check
    /// </summary>
    public static class HealthCheck
    {
        private const string URL_CHECK = "/health-check";

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="configuration">Configuration</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration["ConnectionStrings:SQL_Database"], name: "ListoDatabase")
                .AddSqlServer(configuration["ConnectionStrings:SQL_External"], name: "ListoExternal")
                .AddSqlServer(configuration["ConnectionStrings:SQL_SCD"], name: "ListoSCD")
                .AddMySql(configuration["ConnectionStrings:MySQL"], name: "MySQL");
        }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app">Application</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks(URL_CHECK,
                new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonConvert.SerializeObject(
                            new
                            {
                                statusApplication = report.Status.ToString(),
                                healthChecks = report.Entries.Select(e => new
                                {
                                    check = e.Key,
                                    status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                                })
                            }, Formatting.Indented);
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                }
            );
        }
    }
}
