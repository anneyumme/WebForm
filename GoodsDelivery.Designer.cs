namespace Log_in
{
    partial class GoodsDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsDelivery));
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grd = new System.Windows.Forms.DataGridView();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.orderTotalTXT = new System.Windows.Forms.TextBox();
            this.orderCreateTXT = new System.Windows.Forms.TextBox();
            this.userTXT = new System.Windows.Forms.TextBox();
            this.paymentStatusTXT = new System.Windows.Forms.TextBox();
            this.paymentDueDateTXT = new System.Windows.Forms.TextBox();
            this.cityTXT = new System.Windows.Forms.TextBox();
            this.streetTXT = new System.Windows.Forms.TextBox();
            this.shippingTXT = new System.Windows.Forms.TextBox();
            this.orderStatusTXT = new System.Windows.Forms.TextBox();
            this.sessionIDTXT = new System.Windows.Forms.TextBox();
            this.nameTXT = new System.Windows.Forms.TextBox();
            this.provinceTXT = new System.Windows.Forms.TextBox();
            this.paymentltentIdTXT = new System.Windows.Forms.TextBox();
            this.phoneTXT = new System.Windows.Forms.TextBox();
            this.paymentTypeTXT = new System.Windows.Forms.TextBox();
            this.paymentDateTXT = new System.Windows.Forms.TextBox();
            this.idTXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.grb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb2
            // 
            this.grb2.Controls.Add(this.btnPrintAll);
            this.grb2.Controls.Add(this.btnBack);
            this.grb2.Controls.Add(this.btnPrint);
            this.grb2.Controls.Add(this.btnSave);
            this.grb2.Controls.Add(this.btnUpdate);
            this.grb2.Location = new System.Drawing.Point(436, 234);
            this.grb2.Name = "grb2";
            this.grb2.Size = new System.Drawing.Size(770, 50);
            this.grb2.TabIndex = 10;
            this.grb2.TabStop = false;
            this.grb2.Text = "Function";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(639, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 132;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(363, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 130;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(102, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grd
            // 
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Location = new System.Drawing.Point(5, 290);
            this.grd.Name = "grd";
            this.grd.RowHeadersWidth = 51;
            this.grd.RowTemplate.Height = 24;
            this.grd.Size = new System.Drawing.Size(1748, 254);
            this.grd.TabIndex = 11;
            this.grd.Click += new System.EventHandler(this.grd_Click);
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.orderTotalTXT);
            this.grp1.Controls.Add(this.orderCreateTXT);
            this.grp1.Controls.Add(this.userTXT);
            this.grp1.Controls.Add(this.paymentStatusTXT);
            this.grp1.Controls.Add(this.paymentDueDateTXT);
            this.grp1.Controls.Add(this.cityTXT);
            this.grp1.Controls.Add(this.streetTXT);
            this.grp1.Controls.Add(this.shippingTXT);
            this.grp1.Controls.Add(this.orderStatusTXT);
            this.grp1.Controls.Add(this.sessionIDTXT);
            this.grp1.Controls.Add(this.nameTXT);
            this.grp1.Controls.Add(this.provinceTXT);
            this.grp1.Controls.Add(this.paymentltentIdTXT);
            this.grp1.Controls.Add(this.phoneTXT);
            this.grp1.Controls.Add(this.paymentTypeTXT);
            this.grp1.Controls.Add(this.paymentDateTXT);
            this.grp1.Controls.Add(this.idTXT);
            this.grp1.Controls.Add(this.label4);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.label8);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.label6);
            this.grp1.Controls.Add(this.label17);
            this.grp1.Controls.Add(this.label16);
            this.grp1.Controls.Add(this.label15);
            this.grp1.Controls.Add(this.label14);
            this.grp1.Controls.Add(this.label13);
            this.grp1.Controls.Add(this.label12);
            this.grp1.Controls.Add(this.label11);
            this.grp1.Controls.Add(this.label10);
            this.grp1.Controls.Add(this.label9);
            this.grp1.Controls.Add(this.label5);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Location = new System.Drawing.Point(12, 12);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(1741, 216);
            this.grp1.TabIndex = 12;
            this.grp1.TabStop = false;
            this.grp1.Text = "Information";
            // 
            // orderTotalTXT
            // 
            this.orderTotalTXT.Location = new System.Drawing.Point(130, 166);
            this.orderTotalTXT.Name = "orderTotalTXT";
            this.orderTotalTXT.Size = new System.Drawing.Size(202, 22);
            this.orderTotalTXT.TabIndex = 1;
            // 
            // orderCreateTXT
            // 
            this.orderCreateTXT.Location = new System.Drawing.Point(130, 119);
            this.orderCreateTXT.Name = "orderCreateTXT";
            this.orderCreateTXT.Size = new System.Drawing.Size(202, 22);
            this.orderCreateTXT.TabIndex = 1;
            // 
            // userTXT
            // 
            this.userTXT.Location = new System.Drawing.Point(130, 66);
            this.userTXT.Name = "userTXT";
            this.userTXT.Size = new System.Drawing.Size(202, 22);
            this.userTXT.TabIndex = 1;
            // 
            // paymentStatusTXT
            // 
            this.paymentStatusTXT.Location = new System.Drawing.Point(504, 166);
            this.paymentStatusTXT.Name = "paymentStatusTXT";
            this.paymentStatusTXT.Size = new System.Drawing.Size(202, 22);
            this.paymentStatusTXT.TabIndex = 1;
            // 
            // paymentDueDateTXT
            // 
            this.paymentDueDateTXT.Location = new System.Drawing.Point(504, 113);
            this.paymentDueDateTXT.Name = "paymentDueDateTXT";
            this.paymentDueDateTXT.Size = new System.Drawing.Size(202, 22);
            this.paymentDueDateTXT.TabIndex = 1;
            // 
            // cityTXT
            // 
            this.cityTXT.Location = new System.Drawing.Point(857, 163);
            this.cityTXT.Name = "cityTXT";
            this.cityTXT.Size = new System.Drawing.Size(202, 22);
            this.cityTXT.TabIndex = 1;
            // 
            // streetTXT
            // 
            this.streetTXT.Location = new System.Drawing.Point(857, 119);
            this.streetTXT.Name = "streetTXT";
            this.streetTXT.Size = new System.Drawing.Size(202, 22);
            this.streetTXT.TabIndex = 1;
            // 
            // shippingTXT
            // 
            this.shippingTXT.Location = new System.Drawing.Point(1533, 21);
            this.shippingTXT.Name = "shippingTXT";
            this.shippingTXT.Size = new System.Drawing.Size(202, 22);
            this.shippingTXT.TabIndex = 1;
            // 
            // orderStatusTXT
            // 
            this.orderStatusTXT.Location = new System.Drawing.Point(1189, 166);
            this.orderStatusTXT.Name = "orderStatusTXT";
            this.orderStatusTXT.Size = new System.Drawing.Size(202, 22);
            this.orderStatusTXT.TabIndex = 1;
            // 
            // sessionIDTXT
            // 
            this.sessionIDTXT.Location = new System.Drawing.Point(1189, 116);
            this.sessionIDTXT.Name = "sessionIDTXT";
            this.sessionIDTXT.Size = new System.Drawing.Size(202, 22);
            this.sessionIDTXT.TabIndex = 1;
            // 
            // nameTXT
            // 
            this.nameTXT.Location = new System.Drawing.Point(1189, 66);
            this.nameTXT.Name = "nameTXT";
            this.nameTXT.Size = new System.Drawing.Size(202, 22);
            this.nameTXT.TabIndex = 1;
            // 
            // provinceTXT
            // 
            this.provinceTXT.Location = new System.Drawing.Point(1189, 21);
            this.provinceTXT.Name = "provinceTXT";
            this.provinceTXT.Size = new System.Drawing.Size(202, 22);
            this.provinceTXT.TabIndex = 1;
            // 
            // paymentltentIdTXT
            // 
            this.paymentltentIdTXT.Location = new System.Drawing.Point(857, 21);
            this.paymentltentIdTXT.Name = "paymentltentIdTXT";
            this.paymentltentIdTXT.Size = new System.Drawing.Size(202, 22);
            this.paymentltentIdTXT.TabIndex = 1;
            // 
            // phoneTXT
            // 
            this.phoneTXT.Location = new System.Drawing.Point(857, 66);
            this.phoneTXT.Name = "phoneTXT";
            this.phoneTXT.Size = new System.Drawing.Size(202, 22);
            this.phoneTXT.TabIndex = 1;
            // 
            // paymentTypeTXT
            // 
            this.paymentTypeTXT.Location = new System.Drawing.Point(504, 22);
            this.paymentTypeTXT.Name = "paymentTypeTXT";
            this.paymentTypeTXT.Size = new System.Drawing.Size(202, 22);
            this.paymentTypeTXT.TabIndex = 1;
            // 
            // paymentDateTXT
            // 
            this.paymentDateTXT.Location = new System.Drawing.Point(504, 66);
            this.paymentDateTXT.Name = "paymentDateTXT";
            this.paymentDateTXT.Size = new System.Drawing.Size(202, 22);
            this.paymentDateTXT.TabIndex = 1;
            // 
            // idTXT
            // 
            this.idTXT.Location = new System.Drawing.Point(130, 25);
            this.idTXT.Name = "idTXT";
            this.idTXT.Size = new System.Drawing.Size(202, 22);
            this.idTXT.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "OrderTotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "OrderCreate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "ApplicationUserId";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "PaymentDueDate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "PaymentDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "PaymentStatus";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(381, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "paymentType";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1445, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "ShippingDate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1111, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "SessionId";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1111, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1111, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Province";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(757, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "City";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(757, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "StreetAdress";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(757, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "PhoneNumber";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(756, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "PaymentItentId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1111, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "orderStatus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(497, 18);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(75, 23);
            this.btnPrintAll.TabIndex = 133;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // GoodsDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 723);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.grb2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GoodsDelivery";
            this.Text = "GoodsDelivery";
            this.Load += new System.EventHandler(this.GoodsDelivery_Load);
            this.grb2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grb2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox orderTotalTXT;
        private System.Windows.Forms.TextBox orderCreateTXT;
        private System.Windows.Forms.TextBox userTXT;
        private System.Windows.Forms.TextBox paymentStatusTXT;
        private System.Windows.Forms.TextBox paymentDueDateTXT;
        private System.Windows.Forms.TextBox cityTXT;
        private System.Windows.Forms.TextBox streetTXT;
        private System.Windows.Forms.TextBox shippingTXT;
        private System.Windows.Forms.TextBox orderStatusTXT;
        private System.Windows.Forms.TextBox sessionIDTXT;
        private System.Windows.Forms.TextBox nameTXT;
        private System.Windows.Forms.TextBox provinceTXT;
        private System.Windows.Forms.TextBox paymentltentIdTXT;
        private System.Windows.Forms.TextBox phoneTXT;
        private System.Windows.Forms.TextBox paymentTypeTXT;
        private System.Windows.Forms.TextBox paymentDateTXT;
        private System.Windows.Forms.TextBox idTXT;
        private System.Windows.Forms.Button btnPrintAll;
    }
}