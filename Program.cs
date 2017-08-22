using System.ServiceProcess;
using System;
using System.Reflection;
using System.Threading;
using Autofac;
using Hangfire.WindowsService.Demo.Jobs;
using Hangfire.WindowsService.Demo.Infrastructure;

namespace Hangfire.WindowsService.Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // DI
            var builder = new ContainerBuilder();
            builder.RegisterModule(new JobsModule());
            builder.RegisterModule(new InfrastructureModule());
            var container = builder.Build();

            // Hangfire
            var schedulerConfiguration = container.Resolve<ISchedulerConfiguration>();
            schedulerConfiguration.Configure(container);
            schedulerConfiguration.InitJobs();

            // WinService standard code + debug setup.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HangfireDemo()
            };

            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                RunInteractive(ServicesToRun);
            }
        }

        /// <summary>
        /// Debug-util
        /// </summary>
        /// <param name="servicesToRun"></param>
        static void RunInteractive(ServiceBase[] servicesToRun)
        {
            Console.WriteLine("Services running in interactive mode.");
            Console.WriteLine();

            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Starting {0}...", service.ServiceName);
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.Write("Started");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(
                "Press any key to stop the services and end the process...");
            Console.ReadKey();
            Console.WriteLine();

            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Stopping {0}...", service.ServiceName);
                onStopMethod.Invoke(service, null);
                Console.WriteLine("Stopped");
            }

            Console.WriteLine("All services stopped.");
            // Keep the console alive for a second to allow the user to see the message.
            Thread.Sleep(1000);
        }
    }
}
