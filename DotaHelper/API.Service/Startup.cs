using Business.Main;
using Business.Parser;
using Common.Logger;
using Common.Settings;
using DataModel;
using DataModel.Profilies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbSettingSection = Configuration.GetSection("ConnectionString");
            services.Configure<ConnectionString>(c => dbSettingSection.Bind(c));

            var dbConnectionStringSection = Configuration.GetSection("ConnectionString");

            services.Configure<ConnectionString>(x => dbConnectionStringSection.Bind(x));

            //services.AddDbContext<AppDbContext>();
            services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);
            services.AddScoped<DbContext, AppDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var loggingSettings = new LoggingSettings();
            Configuration.GetSection("Logging").Bind(loggingSettings);
            services.AddSingleton<ICustomFileLogger>(x => ActivatorUtilities.CreateInstance<CustomFileLogger>(x, loggingSettings.LogsFolderPath));

            services.AddMvc();

            services.AddCors(opt =>
            {
                opt.AddPolicy("default",
                    builder => builder
                        // new change before release
                        //.WithOrigins("domain")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(3600)));
            });

            services.AddAutoMapper(typeof(DefaultAutoMapperProfile).Assembly);

            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IParserService, ParserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Route", "{controller}/{action?}/{id?}");
            });
        }
    }
}
