using Autofac;
using Hangfire.WindowsService.Demo.Jobs.Routines;
using Microsoft.Owin.Hosting;
using System;

namespace Hangfire.WindowsService.Demo.Infrastructure
{
    public class HangfireConfiguration : ISchedulerConfiguration
    {
        private readonly IScheduler scheduler;
        private readonly SampleRoutine sampleRoutine;

        public HangfireConfiguration(IScheduler scheduler, SampleRoutine sampleRoutine)
        {
            this.scheduler = scheduler;
            this.sampleRoutine = sampleRoutine;
        }

        public void Configure(IContainer diContainer)
        {
            GlobalConfiguration.Configuration.UseAutofacActivator(diContainer);
            GlobalConfiguration.Configuration.UseSqlServerStorage("hangfire");

            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:9095");
            options.Urls.Add("http://*:9095/");
            options.Urls.Add($"http://{Environment.MachineName}:9095");
            WebApp.Start<Startup>(options);
        }

        public void InitJobs()
        {
            // Consider using reflection in place of injected jobs.
            scheduler.Schedule("Sample routine", sampleRoutine.Action,
                sampleRoutine.CronExpression);
            // Next jobs...
        }
    }
}
