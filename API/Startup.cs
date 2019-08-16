using Api.Filters;
using Api.StartUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    /// <summary>
    /// API StartUp
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// StartUp Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// StartUp Environment
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="env">Environment</param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.Add<CustomExceptionsFilter>();
                options.Filters.Add<ValidateModelStateAttribute>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Cors.Register(Configuration, services);
            //Authorization.Register(services);
            //Authentication.Register(services, Configuration, Environment);
            Repositories.Register(services);
            Swagger.Register(services);
            HealthCheck.Register(services, Configuration);
            Compression.Register(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else { app.UseHsts(); } // Error Page Redirection

            //Localization.Configure(app);
            Swagger.Configure(app, Environment);
            HealthCheck.Configure(app);
            Compression.Configure(app);

            //app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
