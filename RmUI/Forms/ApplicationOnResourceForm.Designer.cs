namespace RmUI.Forms
{
    partial class ApplicationOnResourceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.periodBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endPeriodBox = new System.Windows.Forms.DateTimePicker();
            this.beginPeriodBox = new System.Windows.Forms.DateTimePicker();
            this.ordersBox = new System.Windows.Forms.GroupBox();
            this.orderClearBox = new System.Windows.Forms.Button();
            this.objClearBox = new System.Windows.Forms.Button();
            this.groupObjClearBox = new System.Windows.Forms.Button();
            this.responsibleClearBox = new System.Windows.Forms.Button();
            this.agreeClearBox = new System.Windows.Forms.Button();
            this.enterpriseClearBox = new System.Windows.Forms.Button();
            this.orderFilterBox = new System.Windows.Forms.Button();
            this.objFilterBox = new System.Windows.Forms.Button();
            this.groupObjFilterBox = new System.Windows.Forms.Button();
            this.responsibleFilterBox = new System.Windows.Forms.Button();
            this.agreeFilterBox = new System.Windows.Forms.Button();
            this.enterpriseFilterBox = new System.Windows.Forms.Button();
            this.orderBox = new System.Windows.Forms.TextBox();
            this.objBox = new System.Windows.Forms.TextBox();
            this.groupObjBox = new System.Windows.Forms.TextBox();
            this.responsibleBox = new System.Windows.Forms.TextBox();
            this.agreeBox = new System.Windows.Forms.TextBox();
            this.enterpriseBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.standardBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.periodBox.SuspendLayout();
            this.ordersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // periodBox
            // 
            this.periodBox.Controls.Add(this.label2);
            this.periodBox.Controls.Add(this.label1);
            this.periodBox.Controls.Add(this.endPeriodBox);
            this.periodBox.Controls.Add(this.beginPeriodBox);
            this.periodBox.Location = new System.Drawing.Point(12, 12);
            this.periodBox.Name = "periodBox";
            this.periodBox.Size = new System.Drawing.Size(302, 58);
            this.periodBox.TabIndex = 0;
            this.periodBox.TabStop = false;
            this.periodBox.Text = "Период";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "с";
            // 
            // endPeriodBox
            // 
            this.endPeriodBox.Checked = false;
            this.endPeriodBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endPeriodBox.Location = new System.Drawing.Point(175, 23);
            this.endPeriodBox.Name = "endPeriodBox";
            this.endPeriodBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.endPeriodBox.ShowCheckBox = true;
            this.endPeriodBox.Size = new System.Drawing.Size(99, 20);
            this.endPeriodBox.TabIndex = 1;
            this.endPeriodBox.ValueChanged += new System.EventHandler(this.OnEndPeriodValueChanged);
            // 
            // beginPeriodBox
            // 
            this.beginPeriodBox.Checked = false;
            this.beginPeriodBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.beginPeriodBox.Location = new System.Drawing.Point(35, 23);
            this.beginPeriodBox.Name = "beginPeriodBox";
            this.beginPeriodBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.beginPeriodBox.ShowCheckBox = true;
            this.beginPeriodBox.Size = new System.Drawing.Size(99, 20);
            this.beginPeriodBox.TabIndex = 0;
            this.beginPeriodBox.ValueChanged += new System.EventHandler(this.OnBeginPeriodValueChanged);
            // 
            // ordersBox
            // 
            this.ordersBox.Controls.Add(this.orderClearBox);
            this.ordersBox.Controls.Add(this.objClearBox);
            this.ordersBox.Controls.Add(this.groupObjClearBox);
            this.ordersBox.Controls.Add(this.responsibleClearBox);
            this.ordersBox.Controls.Add(this.agreeClearBox);
            this.ordersBox.Controls.Add(this.enterpriseClearBox);
            this.ordersBox.Controls.Add(this.orderFilterBox);
            this.ordersBox.Controls.Add(this.objFilterBox);
            this.ordersBox.Controls.Add(this.groupObjFilterBox);
            this.ordersBox.Controls.Add(this.responsibleFilterBox);
            this.ordersBox.Controls.Add(this.agreeFilterBox);
            this.ordersBox.Controls.Add(this.enterpriseFilterBox);
            this.ordersBox.Controls.Add(this.orderBox);
            this.ordersBox.Controls.Add(this.objBox);
            this.ordersBox.Controls.Add(this.groupObjBox);
            this.ordersBox.Controls.Add(this.responsibleBox);
            this.ordersBox.Controls.Add(this.agreeBox);
            this.ordersBox.Controls.Add(this.enterpriseBox);
            this.ordersBox.Controls.Add(this.label8);
            this.ordersBox.Controls.Add(this.label7);
            this.ordersBox.Controls.Add(this.label6);
            this.ordersBox.Controls.Add(this.label5);
            this.ordersBox.Controls.Add(this.label4);
            this.ordersBox.Controls.Add(this.label3);
            this.ordersBox.Location = new System.Drawing.Point(12, 76);
            this.ordersBox.Name = "ordersBox";
            this.ordersBox.Size = new System.Drawing.Size(388, 210);
            this.ordersBox.TabIndex = 4;
            this.ordersBox.TabStop = false;
            this.ordersBox.Text = "Заказ";
            // 
            // orderClearBox
            // 
            this.orderClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderClearBox.Location = new System.Drawing.Point(350, 170);
            this.orderClearBox.Name = "orderClearBox";
            this.orderClearBox.Size = new System.Drawing.Size(30, 25);
            this.orderClearBox.TabIndex = 20;
            this.orderClearBox.Text = "x";
            this.orderClearBox.UseVisualStyleBackColor = true;
            this.orderClearBox.Click += new System.EventHandler(this.OnClaimsForMatsCleared);
            // 
            // objClearBox
            // 
            this.objClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.objClearBox.Location = new System.Drawing.Point(350, 140);
            this.objClearBox.Name = "objClearBox";
            this.objClearBox.Size = new System.Drawing.Size(30, 25);
            this.objClearBox.TabIndex = 21;
            this.objClearBox.Text = "x";
            this.objClearBox.UseVisualStyleBackColor = true;
            this.objClearBox.Click += new System.EventHandler(this.OnStockObjCleared);
            // 
            // groupObjClearBox
            // 
            this.groupObjClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupObjClearBox.Location = new System.Drawing.Point(350, 110);
            this.groupObjClearBox.Name = "groupObjClearBox";
            this.groupObjClearBox.Size = new System.Drawing.Size(30, 25);
            this.groupObjClearBox.TabIndex = 20;
            this.groupObjClearBox.Text = "x";
            this.groupObjClearBox.UseVisualStyleBackColor = true;
            // 
            // responsibleClearBox
            // 
            this.responsibleClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.responsibleClearBox.Location = new System.Drawing.Point(350, 80);
            this.responsibleClearBox.Name = "responsibleClearBox";
            this.responsibleClearBox.Size = new System.Drawing.Size(30, 25);
            this.responsibleClearBox.TabIndex = 20;
            this.responsibleClearBox.Text = "x";
            this.responsibleClearBox.UseVisualStyleBackColor = true;
            this.responsibleClearBox.Click += new System.EventHandler(this.OnResponsibleCleared);
            // 
            // agreeClearBox
            // 
            this.agreeClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agreeClearBox.Location = new System.Drawing.Point(350, 50);
            this.agreeClearBox.Name = "agreeClearBox";
            this.agreeClearBox.Size = new System.Drawing.Size(30, 25);
            this.agreeClearBox.TabIndex = 19;
            this.agreeClearBox.Text = "x";
            this.agreeClearBox.UseVisualStyleBackColor = true;
            this.agreeClearBox.Click += new System.EventHandler(this.OnAgreeCleared);
            // 
            // enterpriseClearBox
            // 
            this.enterpriseClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterpriseClearBox.Location = new System.Drawing.Point(350, 20);
            this.enterpriseClearBox.Name = "enterpriseClearBox";
            this.enterpriseClearBox.Size = new System.Drawing.Size(30, 25);
            this.enterpriseClearBox.TabIndex = 18;
            this.enterpriseClearBox.Text = "x";
            this.enterpriseClearBox.UseVisualStyleBackColor = true;
            this.enterpriseClearBox.Click += new System.EventHandler(this.OnEnterpriseCleared);
            // 
            // orderFilterBox
            // 
            this.orderFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderFilterBox.Location = new System.Drawing.Point(315, 170);
            this.orderFilterBox.Name = "orderFilterBox";
            this.orderFilterBox.Size = new System.Drawing.Size(35, 25);
            this.orderFilterBox.TabIndex = 17;
            this.orderFilterBox.Text = "...";
            this.orderFilterBox.UseVisualStyleBackColor = true;
            this.orderFilterBox.Click += new System.EventHandler(this.OnClaimsForMatsFilterClick);
            // 
            // objFilterBox
            // 
            this.objFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.objFilterBox.Location = new System.Drawing.Point(315, 140);
            this.objFilterBox.Name = "objFilterBox";
            this.objFilterBox.Size = new System.Drawing.Size(35, 25);
            this.objFilterBox.TabIndex = 16;
            this.objFilterBox.Text = "...";
            this.objFilterBox.UseVisualStyleBackColor = true;
            this.objFilterBox.Click += new System.EventHandler(this.OnStockObjFilterClick);
            // 
            // groupObjFilterBox
            // 
            this.groupObjFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupObjFilterBox.Location = new System.Drawing.Point(315, 110);
            this.groupObjFilterBox.Name = "groupObjFilterBox";
            this.groupObjFilterBox.Size = new System.Drawing.Size(35, 25);
            this.groupObjFilterBox.TabIndex = 15;
            this.groupObjFilterBox.Text = "...";
            this.groupObjFilterBox.UseVisualStyleBackColor = true;
            this.groupObjFilterBox.Click += new System.EventHandler(this.OnGroupFilterClick);
            // 
            // responsibleFilterBox
            // 
            this.responsibleFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.responsibleFilterBox.Location = new System.Drawing.Point(315, 80);
            this.responsibleFilterBox.Name = "responsibleFilterBox";
            this.responsibleFilterBox.Size = new System.Drawing.Size(35, 25);
            this.responsibleFilterBox.TabIndex = 14;
            this.responsibleFilterBox.Text = "...";
            this.responsibleFilterBox.UseVisualStyleBackColor = true;
            this.responsibleFilterBox.Click += new System.EventHandler(this.OnResponsibleButtonClick);
            // 
            // agreeFilterBox
            // 
            this.agreeFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agreeFilterBox.Location = new System.Drawing.Point(315, 50);
            this.agreeFilterBox.Name = "agreeFilterBox";
            this.agreeFilterBox.Size = new System.Drawing.Size(35, 25);
            this.agreeFilterBox.TabIndex = 13;
            this.agreeFilterBox.Text = "...";
            this.agreeFilterBox.UseVisualStyleBackColor = true;
            this.agreeFilterBox.Click += new System.EventHandler(this.OnAgreeButtonClick);
            // 
            // enterpriseFilterBox
            // 
            this.enterpriseFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterpriseFilterBox.Location = new System.Drawing.Point(315, 20);
            this.enterpriseFilterBox.Name = "enterpriseFilterBox";
            this.enterpriseFilterBox.Size = new System.Drawing.Size(35, 25);
            this.enterpriseFilterBox.TabIndex = 12;
            this.enterpriseFilterBox.Text = "...";
            this.enterpriseFilterBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enterpriseFilterBox.UseVisualStyleBackColor = true;
            this.enterpriseFilterBox.Click += new System.EventHandler(this.OnEnterpriseButtonClick);
            // 
            // orderBox
            // 
            this.orderBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderBox.Location = new System.Drawing.Point(115, 170);
            this.orderBox.Multiline = true;
            this.orderBox.Name = "orderBox";
            this.orderBox.ReadOnly = true;
            this.orderBox.Size = new System.Drawing.Size(200, 25);
            this.orderBox.TabIndex = 11;
            // 
            // objBox
            // 
            this.objBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objBox.Location = new System.Drawing.Point(115, 140);
            this.objBox.Multiline = true;
            this.objBox.Name = "objBox";
            this.objBox.ReadOnly = true;
            this.objBox.Size = new System.Drawing.Size(200, 25);
            this.objBox.TabIndex = 10;
            // 
            // groupObjBox
            // 
            this.groupObjBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupObjBox.Location = new System.Drawing.Point(115, 110);
            this.groupObjBox.Multiline = true;
            this.groupObjBox.Name = "groupObjBox";
            this.groupObjBox.ReadOnly = true;
            this.groupObjBox.Size = new System.Drawing.Size(200, 25);
            this.groupObjBox.TabIndex = 9;
            // 
            // responsibleBox
            // 
            this.responsibleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.responsibleBox.Location = new System.Drawing.Point(115, 80);
            this.responsibleBox.Multiline = true;
            this.responsibleBox.Name = "responsibleBox";
            this.responsibleBox.ReadOnly = true;
            this.responsibleBox.Size = new System.Drawing.Size(200, 25);
            this.responsibleBox.TabIndex = 8;
            // 
            // agreeBox
            // 
            this.agreeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.agreeBox.Location = new System.Drawing.Point(115, 50);
            this.agreeBox.Multiline = true;
            this.agreeBox.Name = "agreeBox";
            this.agreeBox.ReadOnly = true;
            this.agreeBox.Size = new System.Drawing.Size(200, 25);
            this.agreeBox.TabIndex = 7;
            // 
            // enterpriseBox
            // 
            this.enterpriseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enterpriseBox.Location = new System.Drawing.Point(115, 20);
            this.enterpriseBox.Multiline = true;
            this.enterpriseBox.Name = "enterpriseBox";
            this.enterpriseBox.ReadOnly = true;
            this.enterpriseBox.Size = new System.Drawing.Size(200, 25);
            this.enterpriseBox.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Заказ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Номенклатура";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Группы ТМЦ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ответственный";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Договор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Поставщик";
            // 
            // standardBox
            // 
            this.standardBox.AutoSize = true;
            this.standardBox.Location = new System.Drawing.Point(12, 295);
            this.standardBox.Name = "standardBox";
            this.standardBox.Size = new System.Drawing.Size(113, 17);
            this.standardBox.TabIndex = 6;
            this.standardBox.Text = "Показать эталон";
            this.standardBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(325, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.acceptButton.Location = new System.Drawing.Point(244, 320);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "ОК";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // ApplicationOnResourceForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(417, 353);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.standardBox);
            this.Controls.Add(this.ordersBox);
            this.Controls.Add(this.periodBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationOnResourceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильтр: Анализ заявки на ресурсы";
            this.periodBox.ResumeLayout(false);
            this.periodBox.PerformLayout();
            this.ordersBox.ResumeLayout(false);
            this.ordersBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox periodBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endPeriodBox;
        private System.Windows.Forms.DateTimePicker beginPeriodBox;
        private System.Windows.Forms.GroupBox ordersBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox standardBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button orderFilterBox;
        private System.Windows.Forms.Button objFilterBox;
        private System.Windows.Forms.Button groupObjFilterBox;
        private System.Windows.Forms.Button responsibleFilterBox;
        private System.Windows.Forms.Button agreeFilterBox;
        private System.Windows.Forms.Button enterpriseFilterBox;
        private System.Windows.Forms.TextBox orderBox;
        private System.Windows.Forms.TextBox objBox;
        private System.Windows.Forms.TextBox groupObjBox;
        private System.Windows.Forms.TextBox responsibleBox;
        private System.Windows.Forms.TextBox agreeBox;
        private System.Windows.Forms.TextBox enterpriseBox;
        private System.Windows.Forms.Button enterpriseClearBox;
        private System.Windows.Forms.Button responsibleClearBox;
        private System.Windows.Forms.Button agreeClearBox;
        private System.Windows.Forms.Button orderClearBox;
        private System.Windows.Forms.Button objClearBox;
        private System.Windows.Forms.Button groupObjClearBox;
    }
}