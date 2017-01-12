using Quartz;
using Quartz.Impl;

namespace AutoServis.Services
{
    public class EmailReminder
    {
        private readonly string _emailTo;
        private readonly int _interval;
        private readonly string _message;

        public EmailReminder(int interval, string message, string emailTo)
        {
            _interval = interval;
            _message = message;
            _emailTo = emailTo;
        }

        public void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job =
                JobBuilder.Create<EmailRemindJob>()
                    .UsingJobData("message", _message)
                    .UsingJobData("emailTo", _emailTo)
                    .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                (s => s.WithIntervalInMinutes(_interval).WithRepeatCount(0))
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}