using Core.LibraryHelper;
using DEWESDb;
using Quartz;
using Quartz.Impl;

namespace Core.Schedule
{
    public class Scheduler
    {
        private readonly DbScheduleContext _db;
        private readonly LibraryManager _libraryManager;
        private readonly IScheduler _scheduler;
        
        public Scheduler(DbScheduleContext db, LibraryManager libraryManager)
        {
            _db = db;
            _libraryManager = libraryManager;
            var factory = new StdSchedulerFactory();
            _scheduler = factory.GetScheduler().Result;
        }

        public void ToPlan()
        {
            foreach (var i in _db.Schedules)
            {
                var job = JobBuilder.Create<DataTransferJob>()
                    .SetJobData(new JobDataMap()
                    {
                        {nameof(DataTransferJobParameter), new DataTransferJobParameter(i.DataSourceName, i.DataSinkName, i.EDataSourceType, i.EDataSourceFormat)},
                        {nameof(LibraryManager), _libraryManager},
                    })
                    .Build();

                var trigger = TriggerBuilder.Create()
                    .WithSchedule(CronScheduleBuilder.CronSchedule(i.Interval))
                    .Build();

                _scheduler.ScheduleJob(job, trigger);
            }
            _scheduler.Start();
        }
    }
}