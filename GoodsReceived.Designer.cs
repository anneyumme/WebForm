namespace Log_in
{
    partial class GoodsReceived
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
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.TXTBrand = new System.Windows.Forms.ComboBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.spTXT = new System.Windows.Forms.TextBox();
            this.slTXT = new System.Windows.Forms.TextBox();
            this.priceTXT = new System.Windows.Forms.TextBox();
            this.nameTXT = new System.Windows.Forms.TextBox();
            this.idTXT = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.Label();
            this.Brand = new System.Windows.Forms.Label();
            this.sup = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.grd = new System.Windows.Forms.DataGridView();
            this.grb1.SuspendLayout();
            this.grb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grb1
            // 
            this.grb1.Controls.Add(this.TXTBrand);
            this.grb1.Controls.Add(this.dtp);
            this.grb1.Controls.Add(this.spTXT);
            this.grb1.Controls.Add(this.slTXT);
            this.grb1.Controls.Add(this.priceTXT);
            this.grb1.Controls.Add(this.nameTXT);
            this.grb1.Controls.Add(this.idTXT);
            this.grb1.Controls.Add(this.price);
            this.grb1.Controls.Add(this.quantity);
            this.grb1.Controls.Add(this.note);
            this.grb1.Controls.Add(this.Brand);
            this.grb1.Controls.Add(this.sup);
            this.grb1.Controls.Add(this.date);
            this.grb1.Controls.Add(this.ID);
            this.grb1.Location = new System.Drawing.Point(12, 12);
            this.grb1.Name = "grb1";
            this.grb1.Size = new System.Drawing.Size(682, 173);
            this.grb1.TabIndex = 1;
            this.grb1.TabStop = false;
            this.grb1.Text = "Goods information";
            // 
            // TXTBrand
            // 
            this.TXTBrand.FormattingEnabled = true;
            this.TXTBrand.Items.AddRange(new object[] {
            "Apple",
            "Samsung",
            "Xiaomi\t",
            "Nokia\t",
            "Oppo",
            "Redmi"});
            this.TXTBrand.Location = new System.Drawing.Point(396, 102);
            this.TXTBrand.Name = "TXTBrand";
            this.TXTBrand.Size = new System.Drawing.Size(280, 24);
            this.TXTBrand.TabIndex = 6;
            this.TXTBrand.SelectedIndexChanged += new System.EventHandler(this.TXTBrand_SelectedIndexChanged);
            this.TXTBrand.SelectedValueChanged += new System.EventHandler(this.TXTBrand_SelectedValueChanged);
            this.TXTBrand.Click += new System.EventHandler(this.TXTBrand_Click);
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(396, 60);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(280, 22);
            this.dtp.TabIndex = 5;
            // 
            // spTXT
            // 
            this.spTXT.Location = new System.Drawing.Point(106, 105);
            this.spTXT.Name = "spTXT";
            this.spTXT.Size = new System.Drawing.Size(151, 22);
            this.spTXT.TabIndex = 3;
            // 
            // slTXT
            // 
            this.slTXT.Location = new System.Drawing.Point(396, 24);
            this.slTXT.Name = "slTXT";
            this.slTXT.Size = new System.Drawing.Size(280, 22);
            this.slTXT.TabIndex = 4;
            // 
            // priceTXT
            // 
            this.priceTXT.Location = new System.Drawing.Point(217, 139);
            this.priceTXT.Name = "priceTXT";
            this.priceTXT.Size = new System.Drawing.Size(280, 22);
            this.priceTXT.TabIndex = 7;
            // 
            // nameTXT
            // 
            this.nameTXT.Location = new System.Drawing.Point(106, 66);
            this.nameTXT.Name = "nameTXT";
            this.nameTXT.Size = new System.Drawing.Size(151, 22);
            this.nameTXT.TabIndex = 2;
            // 
            // idTXT
            // 
            this.idTXT.Location = new System.Drawing.Point(107, 27);
            this.idTXT.Name = "idTXT";
            this.idTXT.Size = new System.Drawing.Size(150, 22);
            this.idTXT.TabIndex = 1;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(173, 142);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(38, 16);
            this.price.TabIndex = 0;
            this.price.Text = "Price";
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.Location = new System.Drawing.Point(297, 27);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(55, 16);
            this.quantity.TabIndex = 0;
            this.quantity.Text = "Quantity";
            // 
            // note
            // 
            this.note.AutoSize = true;
            this.note.Location = new System.Drawing.Point(6, 66);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(44, 16);
            this.note.TabIndex = 0;
            this.note.Text = "Name";
            // 
            // Brand
            // 
            this.Brand.AutoSize = true;
            this.Brand.Location = new System.Drawing.Point(297, 105);
            this.Brand.Name = "Brand";
            this.Brand.Size = new System.Drawing.Size(43, 16);
            this.Brand.TabIndex = 0;
            this.Brand.Text = "Brand";
            // 
            // sup
            // 
            this.sup.AutoSize = true;
            this.sup.Location = new System.Drawing.Point(6, 105);
            this.sup.Name = "sup";
            this.sup.Size = new System.Drawing.Size(57, 16);
            this.sup.TabIndex = 0;
            this.sup.Text = "Supplier";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(297, 66);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(92, 16);
            this.date.TabIndex = 0;
            this.date.Text = "Date received";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(6, 27);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(64, 16);
            this.ID.TabIndex = 0;
            this.ID.Text = "ID Goods";
            // 
            // grb2
            // 
            this.grb2.Controls.Add(this.saveBtn);
            this.grb2.Controls.Add(this.btnBack);
            this.grb2.Controls.Add(this.deleteBtn);
            this.grb2.Controls.Add(this.editBtn);
            this.grb2.Controls.Add(this.addBtn);
            this.grb2.Location = new System.Drawing.Point(12, 191);
            this.grb2.Name = "grb2";
            this.grb2.Size = new System.Drawing.Size(682, 66);
            this.grb2.TabIndex = 2;
            this.grb2.TabStop = false;
            this.grb2.Text = "Function";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(432, 21);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(78, 31);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(550, 21);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 31);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(311, 21);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(78, 31);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(193, 21);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(78, 31);
            this.editBtn.TabIndex = 9;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(73, 21);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(78, 31);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // grd
            // 
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Location = new System.Drawing.Point(12, 263);
            this.grd.Name = "grd";
            this.grd.RowHeadersWidth = 51;
            this.grd.RowTemplate.Height = 24;
            this.grd.Size = new System.Drawing.Size(682, 185);
            this.grd.TabIndex = 3;
            this.grd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellContentClick);
            this.grd.Click += new System.EventHandler(this.grd_Click);
            // 
            // GoodsReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 462);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.grb2);
            this.Controls.Add(this.grb1);
            this.Name = "GoodsReceived";
            this.Text = "GoodsReceived";
            this.Load += new System.EventHandler(this.GoodsReceived_Load);
            this.grb1.ResumeLayout(false);
            this.grb1.PerformLayout();
            this.grb2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TextBox spTXT;
        private System.Windows.Forms.TextBox slTXT;
        private System.Windows.Forms.TextBox priceTXT;
        private System.Windows.Forms.TextBox nameTXT;
        private System.Windows.Forms.TextBox idTXT;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label quantity;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.Label Brand;
        private System.Windows.Forms.Label sup;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.GroupBox grb2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox TXTBrand;
    }
}