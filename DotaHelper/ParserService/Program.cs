using Common.JobRunner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Topshelf;

namespace ParserService
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();
                var serviceProvider = Bootstrapper.GetServiceProvider(services);

                Configuration = serviceProvider.GetRequiredService<IConfigurationRoot>();

                var instanceName = Configuration.GetValue(typeof(string), "ServiceInstanceName") ?? "NameNotFound";

                HostFactory.Run(configurator =>
                {
                    var name = $"DotaHelperJobService{instanceName}";
                    configurator.SetServiceName(name);
                    configurator.SetDisplayName(name);
                    configurator.SetDescription(name);

                    configurator.RunAsLocalSystem();

                    configurator.Service<JobHostedService>(serviceConfigurator =>
                    {
                        serviceConfigurator.ConstructUsing(() => services.BuildServiceProvider().GetRequiredService<JobHostedService>());

                        serviceConfigurator.WhenStarted((services, hostControl) =>
                        {
                            services.StartAsync(new CancellationToken()).GetAwaiter().GetResult();
                            return true;
                        });

                        serviceConfigurator.WhenStopped((services, hostControl) =>
                        {
                            services.StartAsync(new CancellationToken()).GetAwaiter().GetResult();
                            return true;
                        });
                    });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
