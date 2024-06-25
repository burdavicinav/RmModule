using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using RmDatabase;
using RmDatabase.Entities;
using RmLogger;
using System.IO;
using System.Windows.Forms;

namespace RmReports
{
    public class RmCrystalReportViewer : UserControl
    {
        public string ReportName { get; set; }

        public int OmpUser { get; set; }

        public RmCrystalReportViewer(
            string reportName,
            int ompUser,
            CRParam[] parameters)
        {
            OmpUser = ompUser;
            ReportName = reportName;

            log.Debug("Запуск отчета", ompUser);

            OmpCrReports dbReport = null;

            using (var context = new UnitOfWork())
            {
                dbReport = context.OmpCrReportsRepo.GetByName(ReportName);
            }

            log.Debug("Чтение отчета из БД", ompUser);

            if (dbReport != null)
            {
                string tempPath = Path.GetTempPath();

                if (!Directory.Exists($"{tempPath}\\Crystal"))
                {
                    Directory.CreateDirectory($"{tempPath}\\Crystal");
                }

                using (FileStream stream = File.Create($"{tempPath}\\Crystal\\{ReportName}.rpt"))
                {
                    stream.Write(dbReport.Data, 0, dbReport.Data.Length);
                }

                log.Debug("Сохранение файла", ompUser);

                report = new ReportDocument();
                report.Load($"{tempPath}\\Crystal\\{ReportName}.rpt");

                log.Debug("Чтение файла в буфер", ompUser);

                ParameterFieldDefinitions def_fields = report.DataDefinition.ParameterFields;

                foreach (var param in parameters)
                {
                    ParameterFieldDefinition def_field = def_fields[param.Name];

                    ParameterValues currentValues = def_field.CurrentValues;

                    foreach (var value in param.Values)
                    {
                        ParameterDiscreteValue calc = new ParameterDiscreteValue
                        {
                            Value = value
                        };

                        def_field.CurrentValues.Add(calc);
                    }

                    def_field.ApplyCurrentValues(currentValues);
                }

                log.Warning("Удаление файла из временной директории", ompUser);

                File.Delete($"{tempPath}\\Crystal\\{ReportName}.rpt");

                log.Debug("Отображение отчета", ompUser);

                crViewer = new CrystalReportViewer
                {
                    ReportSource = report,
                    Dock = DockStyle.Fill,
                    ShowRefreshButton = false,
                    ShowLogo = false
                };

                Controls.Add(crViewer);
                Dock = DockStyle.Fill;

                string database = DbSession.Database;
                string dbUser = DbSession.User;
                string dbPassword = DbSession.Password;

                log.Debug($"Подключение пользователя: {database}; {dbUser};", ompUser);

                ConnectionInfo crconnectioninfo = new ConnectionInfo
                {
                    ServerName = database,
                    UserID = dbUser,
                    Password = dbPassword
                };

                foreach (Table crtable in report.Database.Tables)
                {
                    TableLogOnInfo crtablelogoninfo = crtable.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                    crtable.ApplyLogOnInfo(crtablelogoninfo);
                }

                log.Debug("Инициализация отчета завершена!", ompUser);

                //crViewer.ReportRefresh += OnReportRefresh;
            }
            else
            {
                MessageBox.Show("Отчет не задан! Обратитесь к администратору!");
            }
        }

        protected void OnReportRefresh(object sender, ViewerEventArgs e)
        {
            //e.Handled = false;
        }

        private readonly ReportDocument report;

        private readonly CrystalReportViewer crViewer;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}