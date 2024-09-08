namespace MarriageHall.GUI
{
    partial class FrmCustomer
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
            this.panel19 = new System.Windows.Forms.Panel();
            this.txtSearchNameAndPhone = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel33 = new System.Windows.Forms.Panel();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel19);
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Controls.Add(this.panel33);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 720);
            this.panel1.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.txtSearchNameAndPhone);
            this.panel19.Controls.Add(this.label21);
            this.panel19.Location = new System.Drawing.Point(814, 26);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(333, 60);
            this.panel19.TabIndex = 0;
            // 
            // txtSearchNameAndPhone
            // 
            this.txtSearchNameAndPhone.Location = new System.Drawing.Point(120, 14);
            this.txtSearchNameAndPhone.Name = "txtSearchNameAndPhone";
            this.txtSearchNameAndPhone.Size = new System.Drawing.Size(198, 26);
            this.txtSearchNameAndPhone.TabIndex = 0;
            this.txtSearchNameAndPhone.TextChanged += new System.EventHandler(this.txtSearchNameAndPhone_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 20);
            this.label21.TabIndex = 12;
            this.label21.Text = "Tìm kiếm:";
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.panel29);
            this.panel26.Controls.Add(this.panel30);
            this.panel26.Controls.Add(this.panel31);
            this.panel26.Controls.Add(this.panel32);
            this.panel26.Controls.Add(this.btnSave);
            this.panel26.Controls.Add(this.btnEdit);
            this.panel26.Controls.Add(this.btnBooking);
            this.panel26.Controls.Add(this.btnAdd);
            this.panel26.Location = new System.Drawing.Point(814, 92);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(333, 603);
            this.panel26.TabIndex = 1;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.txtPhone);
            this.panel29.Controls.Add(this.label24);
            this.panel29.Location = new System.Drawing.Point(6, 265);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(327, 48);
            this.panel29.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(155, 12);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(157, 26);
            this.txtPhone.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "Số điện thoại:";
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.cboGender);
            this.panel30.Controls.Add(this.label25);
            this.panel30.Location = new System.Drawing.Point(6, 211);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(327, 48);
            this.panel30.TabIndex = 2;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(219, 13);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(93, 28);
            this.cboGender.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "Giới tính:";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.label26);
            this.panel31.Controls.Add(this.txtName);
            this.panel31.Location = new System.Drawing.Point(6, 157);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(327, 48);
            this.panel31.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 20);
            this.label26.TabIndex = 0;
            this.label26.Text = "Tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(154, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 26);
            this.txtName.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.txtId);
            this.panel32.Controls.Add(this.label27);
            this.panel32.Location = new System.Drawing.Point(6, 103);
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(52, 467);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(199, 394);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(100, 40);
            this.btnBooking.TabIndex = 6;
            this.btnBooking.Text = "Đặt tiệc";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(52, 394);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.dgvCustomer);
            this.panel33.Location = new System.Drawing.Point(7, 26);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(801, 669);
            this.panel33.TabIndex = 2;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 3);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersWidth = 62;
            this.dgvCustomer.RowTemplate.Height = 28;
            this.dgvCustomer.Size = new System.Drawing.Size(798, 666);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TextBox txtSearchNameAndPhone;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnBooking;
    }
}