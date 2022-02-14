using Business.Parser;
using Common.Logger;
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
        private readonly ICustomFileLogger _logger;

        public ParseDataJob(IServiceProvider provider, ICustomFileLogger logger)
        {
            _provider = provider;
            _logger = logger;
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
                        await parserService.Parse();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(ex, "Execute job");
                }
                finally
                {
                    IsJobRunned = false;
                }
            }
        }
    }
}
