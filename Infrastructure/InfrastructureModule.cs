using Autofac;

namespace Hangfire.WindowsService.Demo.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HangfireScheduler>().As<IScheduler>().SingleInstance();
            builder.RegisterType<HangfireConfiguration>().As<ISchedulerConfiguration>().SingleInstance();

            base.Load(builder);
        }
    }
}
