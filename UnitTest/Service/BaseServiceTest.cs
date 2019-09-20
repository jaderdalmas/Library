using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Model.Pattern;
using Service;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Xunit;

namespace Tests.Services
{
    /// <summary>
    /// Test for Transaction
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BaseServiceTest : IClassFixture<ServiceWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        private readonly IServiceProvider _serviceProvider;

        public BaseServiceTest(ServiceWebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IUserInfo>(provider => new UserInfo(1, 1));

                    UnitTest.Repository.MockTest.DependencyInjection.Register(services);
                });
            });

            _client = _factory.CreateClient();
            _serviceProvider = _factory.Server.Host.Services.CreateScope().ServiceProvider;
        }

        public INotification GetNotification => _serviceProvider.GetService<INotification>();

        public IBookService GetBookService => _serviceProvider.GetService<IBookService>();
    }
}
