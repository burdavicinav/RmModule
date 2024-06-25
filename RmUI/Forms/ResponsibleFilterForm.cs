using RmDatabase.Entities;
using RmLogger;
using RmUI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RmUI.Forms
{
    public partial class ResponsibleFilterForm : Form
    {
        public List<LabouringList> ResponsibleList { get; private set; }

        public int User { get; private set; }

        public DateTime? OrderBeginDate { get; private set; }

        public DateTime? OrderEndDate { get; private set; }

        public List<Enterprise> Enterprises { get; private set; }

        public List<PAgree> AgreeList { get; private set; }

        public ResponsibleFilterForm()
        {
            InitializeComponent();
        }

        public ResponsibleFilterForm(
            int user, 
            DateTime? beginDate, 
            DateTime? endDate, 
            List<Enterprise> enterprises, 
            List<PAgree> agreeList)
            : this()
        {
            User = user;
            OrderBeginDate = beginDate;
            OrderEndDate = endDate;
            Enterprises = enterprises;
            AgreeList = agreeList;
        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            responsibleScene.Rows.Clear();

            try
            {
                string fullName = fullNameBox.Text;

                using (var context = new UnitOfWork())
                {
                    var responsibleList = context.LabouringListRepo.GetList(
                        fullName,
                        AgreeList,
                        Enterprises,
                        OrderBeginDate,
                        OrderEndDate
                        );

                    List<DataGridViewRow> rows = new List<DataGridViewRow>();

                    foreach (var responsible in responsibleList)
                    {
                        rows.Add(AddRow(responsible));
                    }

                    responsibleScene.Rows.AddRange(rows.ToArray());
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private DataGridViewRow AddRow(LabouringList responsible)
        {
            var row = new DataGridViewRow
            {
                Tag = responsible
            };

            row.CreateCells(
                responsibleScene,
                responsible.FullName
                );

            return row;
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (responsibleScene.SelectedRows.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            ResponsibleList = new List<LabouringList>();

            foreach (DataGridViewRow row in responsibleScene.SelectedRows)
            {
                ResponsibleList.Add(row.Tag as LabouringList);
            }

            DialogResult = DialogResult.OK;
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
