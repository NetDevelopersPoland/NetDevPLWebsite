using System;
using System.Threading;
using NetDevPLBackgoundJobs.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace NetDevPLBackgoundJobs
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                scheduler.Start();
                AddJob(scheduler, new FacebookJob(), "10 0 * * * ?");
                AddJob(scheduler, new NetGroupsUpdateJob(), "20 0 */8 * * ?");
                AddJob(scheduler, new BlogsUpdateJob(), "20 0 */8 * * ?");

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

        public static void AddJob(IScheduler scheduler, IJob job, string cronTime)
        {
            JobDetailImpl jobDetail = new JobDetailImpl(job.GetType().FullName, job.GetType().FullName + "Group", job.GetType());
            CronTriggerImpl trigger = new CronTriggerImpl(job.GetType().FullName + "Trigger", job.GetType().FullName + "Group", cronTime);
            scheduler.ScheduleJob(jobDetail, trigger);
            DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
            Console.WriteLine("Next run time: " + nextFireTime.Value);
        }
    }
}