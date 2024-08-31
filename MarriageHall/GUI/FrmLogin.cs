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

        private bool Login()
        {
            return true;
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
            if (Login())
            {
                FrmHome frmHome = new FrmHome();
                Hide();
                frmHome.ShowDialog();
                Show();
            }

        }
    }
}
