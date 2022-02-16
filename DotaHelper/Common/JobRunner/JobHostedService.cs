using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.JobRunner
{
    public class JobHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobShedule> _jobShedules;

        public IScheduler Scheduler { get; set; }

        public JobHostedService(ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobShedule> jobShedules)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobShedules = jobShedules;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach(var shedule in _jobShedules)
            {
                var job = CreateJob(shedule);
                var trigger = CreateTrigger(shedule);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler.Shutdown(cancellationToken);
        }

        private IJobDetail CreateJob(JobShedule shedule)
        {
            var joType = shedule.JobType;

            return JobBuilder
                .Create(joType)
                .WithIdentity(joType.FullName)
                .WithDescription(joType.Name)
                .Build();
        }

        public ITrigger CreateTrigger(JobShedule shedule)
        {
            var joType = shedule.JobType;

            return TriggerBuilder
                .Create()
                .WithIdentity($"{joType.FullName}.trigger")
                .WithCronSchedule(shedule.CronExpression)
                .WithDescription($"{joType.Name}.trigger-{shedule.CronExpression}")
                .Build();
        }
    }
}
