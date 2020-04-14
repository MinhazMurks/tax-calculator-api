using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Config;
using TaxCalculator.Repository;
using TaxCalculator.Services;
using TaxCalculator.Utilities;

namespace TaxCalculator
{
    /// <summary>
    /// Configuration and service setup, and initialize services in dependency injection container.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor to create a <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// <see cref="IConfiguration"/> to configure settings from <code>appsettings.json</code>.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TaxConfig>(Configuration.GetSection(nameof(TaxConfig)));
            services.AddSingleton(typeof(ITaxConfig), config => config.GetRequiredService<IOptions<TaxConfig>>().Value);
            services.AddSingleton<ITaxRegionsRepository> (serviceProvider => new TaxRegionsRepository(File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/Properties/taxRegions.json")));
            services.AddSingleton(typeof(ITaxInputUtility), typeof(TaxInputUtility));
            services.AddSingleton(typeof(ITaxService), typeof(TaxService));
            services.AddSingleton(typeof(ITaxCalculatorService), typeof(TaxCalculatorService));

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The <see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}