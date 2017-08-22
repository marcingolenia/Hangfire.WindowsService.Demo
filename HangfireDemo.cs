using System.ServiceProcess;

namespace Hangfire.WindowsService.Demo
{
    public partial class HangfireDemo : ServiceBase
    {
        public HangfireDemo()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
