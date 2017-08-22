using System;
using System.Linq.Expressions;

namespace Hangfire.WindowsService.Demo.Jobs.Routines
{
    public interface IRoutineJob
    {
        /// <summary>
        /// http://en.wikipedia.org/wiki/Cron
        /// </summary>
        string CronExpression { get; }

        /// <summary>
        /// Action which will be performed by Hangfire. 
        /// Assigned action to expression is visible in Hangfire administartion panel.
        /// </summary>
        Expression<Action> Action { get; }
    }
}
