using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.JobRunner
{
    public class JobShedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }

        public JobShedule(Type jobType, string cronExpression)
        {
            this.JobType = jobType;
            this.CronExpression = cronExpression;
        }
    }
}
