namespace MarriageHall.GUI
{
    partial class FrmStatisticsItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboStatisticsItemCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.dtpkStatisticsItem = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboStatisticsItemCategory);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lsvItem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpkStatisticsItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 538);
            this.panel1.TabIndex = 0;
            // 
            // cboStatisticsItemCategory
            // 
            this.cboStatisticsItemCategory.FormattingEnabled = true;
            this.cboStatisticsItemCategory.Location = new System.Drawing.Point(345, 49);
            this.cboStatisticsItemCategory.Name = "cboStatisticsItemCategory";
            this.cboStatisticsItemCategory.Size = new System.Drawing.Size(110, 28);
            this.cboStatisticsItemCategory.TabIndex = 2;
            this.cboStatisticsItemCategory.SelectedIndexChanged += new System.EventHandler(this.cboStatisticsItemCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tháng:";
            // 
            // lsvItem
            // 
            this.lsvItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvItem.GridLines = true;
            this.lsvItem.HideSelection = false;
            this.lsvItem.Location = new System.Drawing.Point(13, 98);
            this.lsvItem.Name = "lsvItem";
            this.lsvItem.Size = new System.Drawing.Size(450, 428);
            this.lsvItem.TabIndex = 4;
            this.lsvItem.UseCompatibleStateImageBehavior = false;
            this.lsvItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name                                             ";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thể loại:";
            // 
            // dtpkStatisticsItem
            // 
            this.dtpkStatisticsItem.CustomFormat = "MM/yyyy";
            this.dtpkStatisticsItem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkStatisticsItem.Location = new System.Drawing.Point(82, 47);
            this.dtpkStatisticsItem.Name = "dtpkStatisticsItem";
            this.dtpkStatisticsItem.Size = new System.Drawing.Size(127, 26);
            this.dtpkStatisticsItem.TabIndex = 1;
            this.dtpkStatisticsItem.ValueChanged += new System.EventHandler(this.dtpkStatisticsItem_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê số lượng sản phẩm bán ra";
            // 
            // FrmStatisticsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 544);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStatisticsItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sản phẩm";
            this.Load += new System.EventHandler(this.FrmStatisticsItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpkStatisticsItem;
        private System.Windows.Forms.ListView lsvItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStatisticsItemCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}