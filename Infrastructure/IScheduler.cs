using System;
using System.Linq.Expressions;

namespace Hangfire.WindowsService.Demo.Infrastructure
{
    public interface IScheduler
    {
        /// <summary>
        /// Queue up a job
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="job"></param>
        /// <param name="delay"></param>
        void Schedule<T>(Expression<Action<T>> job, TimeSpan delay);

        /// <summary>
        /// Queue up a job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="delay"></param>
        void Schedule(Expression<Action> job, TimeSpan delay);

        /// <summary>
        /// Queue up a job
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="job"></param>
        /// <param name="date"></param>
        void Schedule<T>(Expression<Action<T>> job, DateTimeOffset date);

        /// <summary>
        /// Queue up a job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="date"></param>
        void Schedule(Expression<Action> job, DateTimeOffset date);

        /// <summary>
        /// Add routine job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="cronExpression">http://en.wikipedia.org/wiki/Cron</param>
        void Schedule(Expression<Action> job, string cronExpression);

        /// <summary>
        /// Add routine job 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="job"></param>
        /// <param name="cronExpression"></param>
        void Schedule(string jobId, Expression<Action> job, string cronExpression);
    }
}
