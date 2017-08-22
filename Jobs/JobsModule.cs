using Autofac;
using Hangfire.WindowsService.Demo.Jobs.Routines;

namespace Hangfire.WindowsService.Demo.Jobs
{
    public class JobsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DiTest>().As<IDiTest>().SingleInstance();
            builder.RegisterType<SampleRoutine>().SingleInstance();

            base.Load(builder);
        }
    }
}
