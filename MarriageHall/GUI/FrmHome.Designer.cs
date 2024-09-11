namespace MarriageHall.GUI
{
    partial class FrmHome
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
            this.mnHome = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmPageIndex = new System.Windows.Forms.NumericUpDown();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.panel19 = new System.Windows.Forms.Panel();
            this.dtpkServiceDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbIsPaid = new System.Windows.Forms.CheckBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panel33 = new System.Windows.Forms.Panel();
            this.dgvBooking = new System.Windows.Forms.DataGridView();
            this.mnHome.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPageIndex)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // mnHome
            // 
            this.mnHome.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnHome.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.kháchHàngToolStripMenuItem});
            this.mnHome.Location = new System.Drawing.Point(0, 0);
            this.mnHome.Name = "mnHome";
            this.mnHome.Size = new System.Drawing.Size(1178, 33);
            this.mnHome.TabIndex = 0;
            this.mnHome.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel19);
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Controls.Add(this.panel33);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 698);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmPageIndex);
            this.panel4.Controls.Add(this.btnLastPage);
            this.panel4.Controls.Add(this.btnFirstPage);
            this.panel4.Location = new System.Drawing.Point(7, 621);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 63);
            this.panel4.TabIndex = 6;
            // 
            // nmPageIndex
            // 
            this.nmPageIndex.Location = new System.Drawing.Point(337, 18);
            this.nmPageIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmPageIndex.Name = "nmPageIndex";
            this.nmPageIndex.Size = new System.Drawing.Size(120, 26);
            this.nmPageIndex.TabIndex = 4;
            this.nmPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmPageIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmPageIndex.ValueChanged += new System.EventHandler(this.nmPageIndex_ValueChanged);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(483, 12);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(141, 37);
            this.btnLastPage.TabIndex = 1;
            this.btnLastPage.Text = "Trang cuối";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(172, 12);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(141, 37);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.Text = "Trang đầu";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.dtpkServiceDate);
            this.panel19.Controls.Add(this.label21);
            this.panel19.Location = new System.Drawing.Point(814, 15);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(333, 49);
            this.panel19.TabIndex = 3;
            // 
            // dtpkServiceDate
            // 
            this.dtpkServiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkServiceDate.Location = new System.Drawing.Point(160, 8);
            this.dtpkServiceDate.Name = "dtpkServiceDate";
            this.dtpkServiceDate.Size = new System.Drawing.Size(157, 26);
            this.dtpkServiceDate.TabIndex = 8;
            this.dtpkServiceDate.ValueChanged += new System.EventHandler(this.dtpkServiceDate_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 20);
            this.label21.TabIndex = 12;
            this.label21.Text = "Ngày phục vụ:";
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.panel6);
            this.panel26.Controls.Add(this.panel5);
            this.panel26.Controls.Add(this.panel3);
            this.panel26.Controls.Add(this.panel2);
            this.panel26.Controls.Add(this.panel29);
            this.panel26.Controls.Add(this.panel30);
            this.panel26.Controls.Add(this.panel31);
            this.panel26.Controls.Add(this.panel32);
            this.panel26.Controls.Add(this.btnUpdate);
            this.panel26.Controls.Add(this.btnDetail);
            this.panel26.Location = new System.Drawing.Point(814, 70);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(333, 614);
            this.panel26.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtCustomerPhone);
            this.panel6.Location = new System.Drawing.Point(6, 116);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(327, 48);
            this.panel6.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số điện thoại";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(154, 13);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(157, 26);
            this.txtCustomerPhone.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtTotalPrice);
            this.panel5.Location = new System.Drawing.Point(6, 224);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(327, 48);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng tiền:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(154, 13);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(157, 26);
            this.txtTotalPrice.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNote);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(6, 332);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 122);
            this.panel3.TabIndex = 5;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(102, 12);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(210, 96);
            this.txtNote.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ghi chú:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCreatedAt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 48);
            this.panel2.TabIndex = 4;
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.Location = new System.Drawing.Point(185, 12);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(127, 26);
            this.txtCreatedAt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày tạo:";
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.txtShift);
            this.panel29.Controls.Add(this.label5);
            this.panel29.Controls.Add(this.ckbIsPaid);
            this.panel29.Location = new System.Drawing.Point(6, 278);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(327, 48);
            this.panel29.TabIndex = 3;
            // 
            // txtShift
            // 
            this.txtShift.Location = new System.Drawing.Point(62, 10);
            this.txtShift.Name = "txtShift";
            this.txtShift.ReadOnly = true;
            this.txtShift.Size = new System.Drawing.Size(70, 26);
            this.txtShift.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ca:";
            // 
            // ckbIsPaid
            // 
            this.ckbIsPaid.AutoSize = true;
            this.ckbIsPaid.Location = new System.Drawing.Point(174, 12);
            this.ckbIsPaid.Name = "ckbIsPaid";
            this.ckbIsPaid.Size = new System.Drawing.Size(137, 24);
            this.ckbIsPaid.TabIndex = 0;
            this.ckbIsPaid.Text = "Đã thanh toán";
            this.ckbIsPaid.UseVisualStyleBackColor = true;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.cboStatus);
            this.panel30.Controls.Add(this.label25);
            this.panel30.Location = new System.Drawing.Point(6, 170);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(327, 48);
            this.panel30.TabIndex = 2;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(155, 13);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(157, 28);
            this.cboStatus.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "Trạng thái:";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.label26);
            this.panel31.Controls.Add(this.txtCustomerName);
            this.panel31.Location = new System.Drawing.Point(6, 62);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(327, 48);
            this.panel31.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(98, 20);
            this.label26.TabIndex = 0;
            this.label26.Text = "Khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(154, 13);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(157, 26);
            this.txtCustomerName.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.txtId);
            this.panel32.Controls.Add(this.label27);
            this.panel32.Location = new System.Drawing.Point(6, 8);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(327, 48);
            this.panel32.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(155, 11);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(157, 26);
            this.txtId.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "Id:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(205, 551);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Enabled = false;
            this.btnDetail.Location = new System.Drawing.Point(57, 551);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(100, 40);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.dgvBooking);
            this.panel33.Location = new System.Drawing.Point(7, 15);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(801, 600);
            this.panel33.TabIndex = 5;
            // 
            // dgvBooking
            // 
            this.dgvBooking.AllowUserToAddRows = false;
            this.dgvBooking.AllowUserToDeleteRows = false;
            this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooking.Location = new System.Drawing.Point(0, 3);
            this.dgvBooking.MultiSelect = false;
            this.dgvBooking.Name = "dgvBooking";
            this.dgvBooking.ReadOnly = true;
            this.dgvBooking.RowHeadersWidth = 62;
            this.dgvBooking.RowTemplate.Height = 28;
            this.dgvBooking.Size = new System.Drawing.Size(798, 594);
            this.dgvBooking.TabIndex = 0;
            this.dgvBooking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooking_CellContentClick);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnHome);
            this.MainMenuStrip = this.mnHome;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý đặt tiệc cưới";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.mnHome.ResumeLayout(false);
            this.mnHome.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmPageIndex)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnHome;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.DataGridView dgvBooking;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCreatedAt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpkServiceDate;
        private System.Windows.Forms.CheckBox ckbIsPaid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.NumericUpDown nmPageIndex;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShift;
    }
}