using MarriageHall.BLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmHome : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Permission); }
        }
        private int totalPage = 1;

        private int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; nmPageIndex.Maximum = value; }
        }

        public FrmHome(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
        }

        void ChangeAccount(PermissionEnum permission)
        {
            adminToolStripMenuItem.Visible = permission == PermissionEnum.Admin;
            tàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.Name + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            Hide();
            frmAdmin.ShowDialog();
            Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfile frmProfile = new FrmProfile(LoginAccount);
            frmProfile.UpdateAccount += FrmProfile_UpdateAccount;
            frmProfile.ShowDialog();
        }

        private void FrmProfile_UpdateAccount(object sender, AccountEvent e)
        {
            tàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản  (" + e.Account.Name + ")";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer(LoginAccount);
            Hide();
            frmCustomer.ShowDialog();
            Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            dgvBooking.DataSource = BLLBooking.Instance.GetPageBooking(dtpkServiceDate.Value, 1);
            TotalPage = BLLBooking.Instance.GetTotalPageBooking(dtpkServiceDate.Value);
            cboStatus.DataSource = EnumExtension.GetListDescriptions<StatusEnum>();
            cboStatus.ValueMember = "Key";
            cboStatus.DisplayMember = "Value";
            txtTotalPrice.Text = 0.ToString("c");
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtTotalPrice.Clear();
            txtTotalPrice.Text = 0.ToString("c");
            txtNote.Clear();
            txtShift.Clear();
            txtCreatedAt.Clear();
            btnDetail.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void nmPageIndex_ValueChanged(object sender, EventArgs e)
        {
            ClearForm();
            dgvBooking.DataSource = BLLBooking.Instance.GetPageBooking(dtpkServiceDate.Value, (int)nmPageIndex.Value);
            TotalPage = BLL.BLLBooking.Instance.GetTotalPageBooking(dtpkServiceDate.Value);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            nmPageIndex.Value = 1;
        }

        private void dtpkServiceDate_ValueChanged(object sender, EventArgs e)
        {
            ClearForm();
             dgvBooking.DataSource = BLLBooking.Instance.GetPageBooking(dtpkServiceDate.Value, 1);
            TotalPage = BLL.BLLBooking.Instance.GetTotalPageBooking(dtpkServiceDate.Value);
        }

        private void dgvBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvBooking.SelectedCells[0].OwningRow;
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
            txtCustomerPhone.Text = row.Cells["CustomerPhone"].Value.ToString();
            cboStatus.SelectedValue = int.Parse(row.Cells["Status"].Value.ToString());
            txtShift.Text = EnumExtension.GetDescription((ShiftEnum)(int.Parse(row.Cells["Shift"].Value.ToString())));
            txtTotalPrice.Text = ((decimal)row.Cells["TotalPrice"].Value).ToString("c");
            ckbIsPaid.Checked = (bool)row.Cells["IsPaid"].Value;
            txtNote.Text = row.Cells["Note"].Value.ToString();
            txtCreatedAt.Text = DateTime.Parse(row.Cells["CreatedAt"].Value.ToString()).ToString("d");
            btnDetail.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            nmPageIndex.Value = totalPage;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                int isPaid = ckbIsPaid.Checked ? 1 : 0;
                int status = (int)cboStatus.SelectedValue;
                if (BLLBooking.Instance.UpdateBooking(id, isPaid, status))
                {
                    MessageBox.Show("Cập nhật đơn hàng thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
