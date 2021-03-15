using DirectoryOfPersons.Application;
using DirectoryOfPersons.Repository;
using DirectoryOfPersons.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using DirectoryOfPersons.WebApi.Extensions;
using DirectoryOfPersons.Filestore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace DirectoryOfPersons.WebApi
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
            services.AddApplicationLayer();
            services.AddPersistenceLayer(Configuration);
            services.AddRepositoryLayer();
            services.AddFilestore();
            services.AddLocalization(options => {
                options.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo>
                {
                    new CultureInfo("ka-GE"),
                    new CultureInfo("en-US")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("DirectoryOfPersons", new OpenApiInfo()
                {
                    Title = "DirectoryOfPersons Api",
                    Version = "4",
                    Description = "Davit Nikoleishvili DirectoryOfPersons Api",
                    Contact = new OpenApiContact()
                    {
                        Email = "datonikoleishvili@gmail.com",
                        Name = "Davit Nikoleishvili"
                    }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseCustomExceptionMiddleware();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerExtension();
        }
    }
}
