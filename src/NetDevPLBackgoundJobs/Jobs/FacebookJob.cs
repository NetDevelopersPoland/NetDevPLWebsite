using System;
using Quartz;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class FacebookJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job work....");
        }
    }
}