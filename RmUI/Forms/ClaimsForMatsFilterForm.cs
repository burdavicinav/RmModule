using RmDatabase.DTO;
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
    public partial class ClaimsForMatsFilterForm : Form
    {
        public List<ClaimsForMats> ClaimsForMatsList { get; set; }

        public List<Enterprise> Enterprises { get; private set; }

        public List<PAgree> AgreeList { get; private set; }

        public List<StockObj> StockObjList { get; private set; }
        
        public List<LabouringList> ResponsibleList { get; private set; }

        public int User { get; private set; }

        public DateTime? OrderBeginDate { get; private set; }

        public DateTime? OrderEndDate { get; private set; }

        public ClaimsForMatsFilterForm()
        {
            InitializeComponent();
        }

        public ClaimsForMatsFilterForm(
            int user,
            List<StockObj> stockObjList,
            List<LabouringList> responsibleList,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate)
            : this()
        {
            User = user;
            StockObjList = stockObjList;
            ResponsibleList = responsibleList;
            AgreeList = agreeList;
            Enterprises = enterprises;
            OrderBeginDate = orderBeginDate;
            OrderEndDate = orderEndDate;
        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            orderScene.Rows.Clear();

            try
            {
                string orderNum = orderNumBox.Text;

                DateTime? orderDate = null;

                if (orderDateBox.Checked)
                {
                    orderDate = orderDateBox.Value.Date;
                }

                using (var context = new UnitOfWork())
                {
                    var enterprises = context.ClaimsForMatsRepo.GetList(
                        orderNum,
                        orderDate,
                        StockObjList,
                        ResponsibleList,
                        AgreeList,
                        Enterprises,
                        OrderBeginDate,
                        OrderEndDate
                        );

                    List<DataGridViewRow> rows = new List<DataGridViewRow>();

                    foreach (var enterpise in enterprises)
                    {
                        rows.Add(AddRow(enterpise));
                    }

                    orderScene.Rows.AddRange(rows.ToArray());
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private DataGridViewRow AddRow(ClaimsForMats claim)
        {
            var row = new DataGridViewRow
            {
                Tag = claim
            };

            row.CreateCells(
                orderScene,
                claim.Num,
                claim.OrderDate
                );

            return row;
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (orderScene.SelectedRows.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            ClaimsForMatsList = new List<ClaimsForMats>();

            foreach (DataGridViewRow row in orderScene.SelectedRows)
            {
                ClaimsForMatsList.Add(row.Tag as ClaimsForMats);
            }

            DialogResult = DialogResult.OK;
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
