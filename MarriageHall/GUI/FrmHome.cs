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
    }
}
