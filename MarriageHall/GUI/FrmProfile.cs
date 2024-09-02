using MarriageHall.BLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmProfile : Form
    {
        public Account LoginAccount { get; set; }

        public FrmProfile(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            cboGender.DataSource = EnumExtension.GetListDescriptions<GenderEnum>();
            cboGender.ValueMember = "Key";
            cboGender.DisplayMember = "Value";
            txtUserName.Text = LoginAccount.UserName;
            txtName.Text = LoginAccount.Name;
            txtPhone.Text = LoginAccount.Phone;
            cboGender.SelectedValue = (int)LoginAccount.Gender;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Account account= new Account();
            account.Id = LoginAccount.Id;
            account.UserName = LoginAccount.UserName;
            account.Permission = LoginAccount.Permission;
            account.Name = txtName.Text;
            account.Phone = txtPhone.Text;
            account.Gender = (GenderEnum)cboGender.SelectedValue;

            if (BLLAccount.Instance.Login(account.UserName, txtPassword.Text))
            {
                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                if (newPassword.Length > 0)
                {
                    if (!newPassword.Equals(confirmPassword))
                    {
                        MessageBox.Show("Mật khẩu mới không khớp!", "Thông báo");
                        return;
                    }
                    BLLAccount.Instance.ChangePassword(account.Id, newPassword);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                }
                BLLAccount.Instance.UpdateAccount(account);
                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo");
            } 
            else
            {
                MessageBox.Show("Mật khẩu không chính xác!", "Thông báo");
            }

            updateAccount(this, new AccountEvent(account));

            txtPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }

    public class AccountEvent : EventArgs
    {
        public Account Account { get; set; }

        public AccountEvent(Account account)
        {
            Account = account;
        }
    }
}
