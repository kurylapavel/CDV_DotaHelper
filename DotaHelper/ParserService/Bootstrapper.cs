using Business.Parser;
using Common.JobRunner;
using Common.Logger;
using Common.Settings;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParserService.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserService
{
    internal class Bootstrapper
    {
        public static IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            services.AddSingleton(configuration);

            var appSettingsSection = configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var dbSettingsSection = configuration.GetSection("connectionString");
            var loggingSettings = configuration.GetSection("Logging");

            services.Configure<AppSettings>(x => appSettingsSection.Bind(x));
            services.Configure<ConnectionString>(x => dbSettingsSection.Bind(x));
            services.Configure<LoggingSettings>(x => loggingSettings.Bind(x));

            //services.AddDbContext<AppDbContext>();
            services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);
            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IParserService, Business.Parser.ParserService>();

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<ICustomFileLogger, CustomFileLogger>();

            services.AddSingleton<ParseDataJob>();


            services.AddSingleton(new JobShedule(
                    jobType: typeof(ParseDataJob),
                    cronExpression: appSettings.ParseJobCronExpression));


            services.AddTransient<JobHostedService>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
