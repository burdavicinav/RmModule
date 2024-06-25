using RmDatabase.DTO;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RmUI.Forms
{
    public partial class ApplicationOnResourceForm : Form
    {
        public DateTime? BeginPeriod 
        { 
            get
            {
                if (beginPeriodBox.Checked) return beginPeriodBox.Value;

                return null;
            }
        }

        public DateTime? EndPeriod
        {
            get
            {
                if (endPeriodBox.Checked) return endPeriodBox.Value;

                return null;
            }
        }

        public bool IsShowStandard
        {
            get
            {
                return standardBox.Checked;
            }
        }

        public List<Enterprise> Enterprises { get; private set; }

        public List<PAgree> AgreeList { get; private set; }

        public List<LabouringList> ResponsibleList { get; private set; }

        public List<ClassifyNode> GroupList { get; private set; }

        public List<StockObj> StockObjList { get; private set; }

        public List<ClaimsForMats> ClaimsForMatsList { get; private set; }

        public ApplicationOnResourceForm()
        {
            InitializeComponent();
        }

        public ApplicationOnResourceForm(int user)
            : this()
        {
            this.user = user;

            Enterprises = new List<Enterprise>();
            AgreeList = new List<PAgree>();
            ResponsibleList = new List<LabouringList>();
            GroupList = new List<ClassifyNode>();
            StockObjList = new List<StockObj>();
            ClaimsForMatsList = new List<ClaimsForMats>();

            //Test();
        }

        private void OnBeginPeriodValueChanged(object sender, EventArgs e)
        {
            OnEnterpriseCleared(sender, e);
        }

        private void OnEndPeriodValueChanged(object sender, EventArgs e)
        {
            OnEnterpriseCleared(sender, e);
        }

        private void OnEnterpriseButtonClick(object sender, System.EventArgs e)
        {
            DateTime? beginDate = null, endDate = null;

            if (beginPeriodBox.Checked)
            {
                beginDate = beginPeriodBox.Value.Date;
            }

            if (endPeriodBox.Checked)
            {
                endDate = endPeriodBox.Value.Date;
            }

            var filter = new EnterpriseFilterForm(
                user,
                beginDate,
                endDate
                );

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var enterpriseBuilder = new StringBuilder();

                foreach(var enterprise in filter.Enterprises)
                {
                    enterpriseBuilder.Append(enterprise.Name);
                    enterpriseBuilder.Append("; ");
                }

                Enterprises = filter.Enterprises;
                enterpriseBox.Text = enterpriseBuilder.ToString();

                OnAgreeCleared(sender, e);
            }
        }

        private void OnAgreeButtonClick(object sender, EventArgs e)
        {
            DateTime? beginDate = null, endDate = null;

            if (beginPeriodBox.Checked)
            {
                beginDate = beginPeriodBox.Value.Date;
            }

            if (endPeriodBox.Checked)
            {
                endDate = endPeriodBox.Value.Date;
            }

            var filter = new AgreeFilterForm(
                user,
                beginDate,
                endDate,
                Enterprises
                );

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var agreeBuilder = new StringBuilder();

                foreach (var agree in filter.AgreeList)
                {
                    agreeBuilder.Append(agree.AgreeNum);
                    agreeBuilder.Append("; ");
                }

                AgreeList = filter.AgreeList;
                agreeBox.Text = agreeBuilder.ToString();

                OnResponsibleCleared(sender, e);
            }
        }

        private void OnResponsibleButtonClick(object sender, EventArgs e)
        {
            DateTime? beginDate = null, endDate = null;

            if (beginPeriodBox.Checked)
            {
                beginDate = beginPeriodBox.Value.Date;
            }

            if (endPeriodBox.Checked)
            {
                endDate = endPeriodBox.Value;
            }

            var filter = new ResponsibleFilterForm(
                user,
                beginDate,
                endDate,
                Enterprises,
                AgreeList
                );

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var responsibleBuilder = new StringBuilder();

                foreach (var responsible in filter.ResponsibleList)
                {
                    responsibleBuilder.Append(responsible.FullName);
                    responsibleBuilder.Append("; ");
                }

                ResponsibleList = filter.ResponsibleList;
                responsibleBox.Text = responsibleBuilder.ToString();

                OnStockObjCleared(sender, e);
            }
        }

        private void OnGroupFilterClick(object sender, EventArgs e)
        {
            var filter = new ClassifyFilterForm(user);

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var groupBuilder = new StringBuilder();

                foreach (var group in filter.GroupList)
                {
                    groupBuilder.Append(group.Description);
                    groupBuilder.Append("; ");
                }

                GroupList = filter.GroupList;
                groupObjBox.Text = groupBuilder.ToString();

                OnStockObjCleared(sender, e);
            }
        }

        private void OnStockObjFilterClick(object sender, EventArgs e)
        {
            DateTime? beginDate = null, endDate = null;

            if (beginPeriodBox.Checked)
            {
                beginDate = beginPeriodBox.Value.Date;
            }

            if (endPeriodBox.Checked)
            {
                endDate = endPeriodBox.Value.Date;
            }

            var filter = new StockObjFilterForm(
                user,
                beginDate,
                endDate,
                Enterprises,
                AgreeList,
                ResponsibleList,
                GroupList
                );

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var stockObjBuilder = new StringBuilder();

                foreach (var responsible in filter.StockObjList)
                {
                    stockObjBuilder.Append(responsible.Sign);
                    stockObjBuilder.Append("; ");
                }

                StockObjList = filter.StockObjList;
                objBox.Text = stockObjBuilder.ToString();

                OnClaimsForMatsCleared(sender, e);
            }
        }

        private void OnClaimsForMatsFilterClick(object sender, EventArgs e)
        {
            DateTime? orderBeginDate = null, orderEndDate = null;

            if (beginPeriodBox.Checked)
            {
                orderBeginDate = beginPeriodBox.Value.Date;
            }

            if (endPeriodBox.Checked)
            {
                orderEndDate = endPeriodBox.Value.Date;
            }

            var filter = new ClaimsForMatsFilterForm(
                user,
                StockObjList,
                ResponsibleList,
                AgreeList,
                Enterprises,
                orderBeginDate,
                orderEndDate
                );

            if (filter.ShowDialog() == DialogResult.OK)
            {
                var ordersBuilder = new StringBuilder();

                foreach (var responsible in filter.ClaimsForMatsList)
                {
                    ordersBuilder.Append(responsible.Num);
                    ordersBuilder.Append("; ");
                }

                ClaimsForMatsList = filter.ClaimsForMatsList;
                orderBox.Text = ordersBuilder.ToString();
            }
        }

        private void OnEnterpriseCleared(object sender, EventArgs e)
        {
            Enterprises.Clear();
            enterpriseBox.Text = string.Empty;

            OnAgreeCleared(sender, e);
        }

        private void OnAgreeCleared(object sender, EventArgs e)
        {
            AgreeList.Clear();
            agreeBox.Text = string.Empty;

            OnResponsibleCleared(sender, e);
        }

        private void OnResponsibleCleared(object sender, EventArgs e)
        {
            ResponsibleList.Clear();
            responsibleBox.Text = string.Empty;

            OnStockObjCleared(sender, e);
        }

        private void OnStockObjCleared(object sender, EventArgs e)
        {
            StockObjList.Clear();
            objBox.Text = string.Empty;

            OnClaimsForMatsCleared(sender, e);
        }

        private void OnClaimsForMatsCleared(object sender, EventArgs e)
        {
            ClaimsForMatsList.Clear();
            orderBox.Text = string.Empty;
        }

        private readonly int user;
    }
}