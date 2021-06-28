using Company.Application;
using Company.Domain;
using Company.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompanyAPI", Version = "v1" });
            });

           DatabaseSettings databaseSettings = this.ConfiguraAppSettings(services, this.Configuration);

            services
                .AddApplication()
                .AddInfra(databaseSettings)
                .AddDomain();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private DatabaseSettings ConfiguraAppSettings(IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            var databaseSettings = new DatabaseSettings();
            configuration.Bind("DatabaseSettings", databaseSettings);

            services.AddTransient<DatabaseSettings>(x =>
            {
                return databaseSettings;
            });

            return databaseSettings;
        }
    }
}
