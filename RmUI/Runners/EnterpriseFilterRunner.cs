using RmLogger;

using RmUI.Forms;
using System;

namespace RmUI.Runners
{
    public class EnterpriseFilterRunner
    {
        public EnterpriseFilterRunner(int user, DateTime? beginDate, DateTime? endDate)
        {
            this.user = user;
            this.beginDate = beginDate;
            this.endDate = endDate;
        }

        public void Run()
        {
            (new EnterpriseFilterForm(user, beginDate, endDate))
                .ShowDialog();
        }

        private int user;

        private DateTime? beginDate;

        private DateTime? endDate;
    }
}
