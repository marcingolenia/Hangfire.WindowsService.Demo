using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.WindowsService.Demo.Startup))]

namespace Hangfire.WindowsService.Demo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire");
        }
    }
}
