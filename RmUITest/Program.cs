using RmUI.Runners;
using System;

namespace RmUITest
{
    internal class Program
    {
        private const int user = 10617;

        [STAThread]
        public static void Main(string[] args)
        {
            (new ApplicationOnResourceRunner(user))
                .Run();

            //(new EnterpriseFilterRunner()).Run();
        }
    }
}
