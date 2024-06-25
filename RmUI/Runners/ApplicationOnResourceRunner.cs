using RmDatabase.DTO;
using RmDatabase.Entities;
using RmLogger;
using RmReports;
using RmUI.Forms;
using RmUI.Reports;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace RmUI.Runners
{
    public class ApplicationOnResourceRunner : IRunner
    {
        public ApplicationOnResourceRunner(int user) 
        {
            this.user = user;
        }

        public void Run()
        {
            log.Info("Запуск анализа заявки на ресурсы", user);

            var filter = new ApplicationOnResourceForm(user);

            if (filter.ShowDialog() == DialogResult.OK)
            {
                // map parameters
                var crParams = ApplicationOnResourceMapCR.GetCrystalReportParams(
                                                            filter.BeginPeriod,
                                                            filter.EndPeriod,
                                                            filter.Enterprises,
                                                            filter.AgreeList,
                                                            filter.ResponsibleList,
                                                            filter.GroupList,
                                                            filter.StockObjList,
                                                            filter.ClaimsForMatsList,
                                                            filter.IsShowStandard);

                string reportName = ApplicationOnResourceMapCR.GetCrystalReport();

                // запуск CR формы
                RmCrystalReportViewer viewer = new RmCrystalReportViewer(
                    reportName: reportName,
                    ompUser: user,
                    parameters: crParams);

                Form reportForm = new Form
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Size = new System.Drawing.Size(1000, 800)
                };

                reportForm.Controls.Add(viewer);
                reportForm.ShowDialog();
            }
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly int user;
    }
}
