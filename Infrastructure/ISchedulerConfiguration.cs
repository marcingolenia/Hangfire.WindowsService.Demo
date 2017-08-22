using Autofac;

namespace Hangfire.WindowsService.Demo.Infrastructure
{
    public interface ISchedulerConfiguration
    {
        /// <summary>
        /// Startup configuration
        /// </summary>
        void Configure(IContainer scope);

        /// <summary>
        /// Register predefined jobs
        /// </summary>
        void InitJobs();
    }
}
