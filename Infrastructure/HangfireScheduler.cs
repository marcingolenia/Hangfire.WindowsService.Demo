using System;
using System.Linq.Expressions;

namespace Hangfire.WindowsService.Demo.Infrastructure
{
    public class HangfireScheduler : IScheduler
    {
        public void Schedule<T>(Expression<Action<T>> job, TimeSpan delay)
        {
            BackgroundJob.Schedule(job, delay);
        }

        public void Schedule(Expression<Action> job, TimeSpan delay)
        {
            BackgroundJob.Schedule(job, delay);
        }

        public void Schedule<T>(Expression<Action<T>> job, DateTimeOffset date)
        {
            BackgroundJob.Schedule(job, date);
        }

        public void Schedule(Expression<Action> job, DateTimeOffset date)
        {
            BackgroundJob.Schedule(job, date);
        }

        public void Schedule(Expression<Action> job, string cronExpression)
        {
            RecurringJob.AddOrUpdate(job, cronExpression);
        }

        public void Schedule(string jobId, Expression<Action> job, string cronExpression)
        {
            RecurringJob.AddOrUpdate(jobId, job, cronExpression);
        }
    }
}
