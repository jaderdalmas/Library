using Api.StartUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Tests.Services
{
    public class ServiceWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.Test.json", optional: true, reloadOnChange: true);
            });

            // if you want to override Physical database with in-memory database
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor()
                {
                    HttpContext = new DefaultHttpContext() {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                        {
                            new Claim(Authentication.Name, "name@1"),
                            new Claim(Authentication.UserId, "1")
                        }, "mock"))
                    }
                });
            });
        }
    }
}
