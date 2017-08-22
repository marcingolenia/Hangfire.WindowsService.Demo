using System;

namespace Hangfire.WindowsService.Demo.Jobs.Routines
{
    /// <summary>
    /// Dummy stuff to check if DI works.
    /// </summary>
    public interface IDiTest
    {
        void Dummy();
    }

    public class DiTest: IDiTest
    {
        public void Dummy()
        {
            Console.Write("dummy");
            Console.WriteLine();
        }
    }
}
