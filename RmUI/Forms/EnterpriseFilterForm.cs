using RmDatabase.Entities;
using RmLogger;
using RmUI.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RmUI.Forms
{
    public partial class EnterpriseFilterForm : Form
    {
        public List<Enterprise> Enterprises { get; private set; }

        public int User { get; private set; }

        public DateTime? BeginDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public EnterpriseFilterForm()
        {
            InitializeComponent();
        }

        public EnterpriseFilterForm(int user, DateTime? beginDate, DateTime? endDate)
            : this()
        {
            User = user;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            enterpriseScene.Rows.Clear();

            try
            {
                string name = nameBox.Text;
                string inn = innBox.Text;
                string plCode = codeBox.Text;

                using (var context = new UnitOfWork())
                {
                    var enterprises = context.EnterpriseRepo.GetList(
                        name, 
                        inn, 
                        plCode,
                        BeginDate,
                        EndDate
                        );

                    List<DataGridViewRow> rows = new List<DataGridViewRow>();

                    foreach (var enterpise in enterprises)
                    {
                        rows.Add(AddRow(enterpise));
                    }

                    enterpriseScene.Rows.AddRange(rows.ToArray());
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private DataGridViewRow AddRow(Enterprise enterprise)
        {
            var row = new DataGridViewRow
            {
                Tag = enterprise
            };

            row.CreateCells(
                enterpriseScene,
                enterprise.Name,
                enterprise.TaxPayerCode,
                enterprise.PlCode
                );

            return row;
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (enterpriseScene.SelectedRows.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            Enterprises = new List<Enterprise>();

            foreach (DataGridViewRow row in enterpriseScene.SelectedRows)
            {
                Enterprises.Add(row.Tag as Enterprise);
            }

            DialogResult = DialogResult.OK;
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
