using MarriageHall.BLL;
using MarriageHall.DTO;
using System;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            txtUserName.Clear();
            txtPassword.Clear();
            if (BLLAccount.Instance.Login(userName, password))
            {
                Account loginAccount = BLLAccount.Instance.GetAccountByUserName(userName);
                FrmHome frmHome = new FrmHome(loginAccount);
                Hide();
                frmHome.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo");
            }
        }
    }
}
