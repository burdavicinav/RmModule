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
    public partial class AgreeFilterForm : Form
    {
        public List<PAgree> AgreeList { get; private set; }

        public int User { get; private set; }

        public DateTime? OrderBeginDate { get; private set; }

        public DateTime? OrderEndDate { get; private set; }

        public List<Enterprise> Enterprises { get; private set; }

        public AgreeFilterForm()
        {
            InitializeComponent();
        }

        public AgreeFilterForm(int user, DateTime? beginDate, DateTime? endDate, List<Enterprise> enterprises)
            : this()
        {
            User = user;
            OrderBeginDate = beginDate;
            OrderEndDate = endDate;
            Enterprises = enterprises;
        }

        private void AgreeFilterForm_Load(object sender, EventArgs e)
        {

        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            agreeScene.Rows.Clear();

            try
            {
                string agreeNum = agreeNumBox.Text;
                DateTime? agreeDate = null;

                if (agreeDateBox.Checked)
                {
                    agreeDate = agreeDateBox.Value.Date;
                }

                using (var context = new UnitOfWork())
                {
                    var agreeList = context.PAgreeRepo.GetList(
                        agreeNum,
                        agreeDate,
                        Enterprises,
                        OrderBeginDate,
                        OrderEndDate
                        );

                    List<DataGridViewRow> rows = new List<DataGridViewRow>();

                    foreach (var agree in agreeList)
                    {
                        rows.Add(AddRow(agree));
                    }

                    agreeScene.Rows.AddRange(rows.ToArray());
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private DataGridViewRow AddRow(PAgree agree)
        {
            var row = new DataGridViewRow
            {
                Tag = agree
            };

            row.CreateCells(
                agreeScene,
                agree.AgreeNum,
                agree.AgreeDate
                );

            return row;
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (agreeScene.SelectedRows.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            AgreeList = new List<PAgree>();

            foreach (DataGridViewRow row in agreeScene.SelectedRows)
            {
                AgreeList.Add(row.Tag as PAgree);
            }

            DialogResult = DialogResult.OK;
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
