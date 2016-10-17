using System;
using System.Threading;
using NetDevPL.Infrastructure.SharedKernel;
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
            string jobName = job.GetType().FullName;
            JobDetailImpl jobDetail = new JobDetailImpl(jobName, jobName + "Group", job.GetType());
            CronTriggerImpl trigger = new CronTriggerImpl(jobName + "Trigger", job.GetType().FullName + "Group", cronTime);
            scheduler.ScheduleJob(jobDetail, trigger);
            DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();

            Logger.Info(String.Format("{0} - next run time: {1}", jobName, nextFireTime.Value));
        }
    }
}