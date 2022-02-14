using Business.Parser;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParserService.Jobs
{
    public class ParseDataJob : IJob
    {
        private static bool IsJobRunned { get; set; }

        private readonly IServiceProvider _provider;

        public ParseDataJob(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if (!IsJobRunned)
            {
                try
                {
                    IsJobRunned = true;
                    var services = new ServiceCollection();

                    Bootstrapper.GetServiceProvider(services);
                    var provider = services.BuildServiceProvider();

                    IParserService parserService = provider.GetRequiredService<IParserService>();

                    using (var scope = _provider.CreateScope())
                    {
                        //To do => add logger here
                        await parserService.Parse();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exciption {e.Message}");
                }
                finally
                {
                    IsJobRunned = false;
                }
            }
        }
    }
}
