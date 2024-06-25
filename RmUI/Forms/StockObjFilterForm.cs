using RmDatabase.DTO;
using RmDatabase.Entities;
using RmLogger;
using RmUI.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RmUI.Forms
{
    public partial class StockObjFilterForm : Form
    {
        public List<StockObj> StockObjList { get; private set; }

        public int User { get; private set; }

        public DateTime? BeginDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public StockObjFilterForm()
        {
            InitializeComponent();
        }

        public StockObjFilterForm(
            int user, 
            DateTime? beginDate, 
            DateTime? endDate,
            List<Enterprise> enterprises,
            List<PAgree> agreeList,
            List<LabouringList> responsibleList,
            List<ClassifyNode> groups
            )
            : this()
        {
            User = user;
            BeginDate = beginDate;
            EndDate = endDate;
            this.enterprises = enterprises;
            this.agreeList = agreeList;
            this.responsibleList = responsibleList;
            this.groups = groups;
        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            stockObjScene.Rows.Clear();

            try
            {
                string sign = signBox.Text;
                string description = descriptionBox.Text;

                using (var context = new UnitOfWork())
                {
                    var objList = context.StockObjRepo.GetList(
                        sign,
                        description,
                        groups,
                        responsibleList,
                        agreeList,
                        enterprises,
                        BeginDate,
                        EndDate
                        );

                    List<DataGridViewRow> rows = new List<DataGridViewRow>();

                    foreach (var obj in objList)
                    {
                        rows.Add(AddRow(obj));
                    }

                    stockObjScene.Rows.AddRange(rows.ToArray());
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private DataGridViewRow AddRow(StockObj obj)
        {
            var row = new DataGridViewRow
            {
                Tag = obj
            };

            row.CreateCells(
                stockObjScene,
                obj.Sign,
                obj.Description
                );

            return row;
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (stockObjScene.SelectedRows.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            StockObjList = new List<StockObj>();

            foreach (DataGridViewRow row in stockObjScene.SelectedRows)
            {
                StockObjList.Add(row.Tag as StockObj);
            }

            DialogResult = DialogResult.OK;
        }

        private List<Enterprise> enterprises;

        private List<PAgree> agreeList;

        private List<LabouringList> responsibleList;

        private List<ClassifyNode> groups;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
