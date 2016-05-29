using System;
using System.Threading;
using NetDevPLBackgoundJobs.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace NetDevPLBackgoundJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                scheduler.Start();
                AddJob(scheduler);

                while (true)
                {
                    Thread.Sleep(1000 * 31337);
                }

                //scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
        public static void AddJob(IScheduler scheduler)
        {
            IJob job = new FacebookJob();
            JobDetailImpl jobDetail = new JobDetailImpl(job.GetType().FullName, job.GetType().FullName + "Group", job.GetType());
            CronTriggerImpl trigger = new CronTriggerImpl(job.GetType().FullName + "Trigger", job.GetType().FullName + "Group", "* 0 * * * ?");
            scheduler.ScheduleJob(jobDetail, trigger);
            DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
            Console.WriteLine("Next run time: " + nextFireTime.Value);
        }
    }
}