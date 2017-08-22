using System;
using System.Linq.Expressions;

namespace Hangfire.WindowsService.Demo.Jobs.Routines
{
    public class SampleRoutine: IRoutineJob
    {
        private readonly IDiTest test;

        public string CronExpression
        {
            get { return "*/1 * * * *"; }
        }

        public Expression<Action> Action
        {
            get
            {
                return ()=> RunTest();
            }
        }

        public SampleRoutine(IDiTest test)
        {
            this.test = test;
        }

        public void RunTest()
        {
            test.Dummy();
        }
    }
}
