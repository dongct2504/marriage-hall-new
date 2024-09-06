using MarriageHall.BLL;
using MarriageHall.DTO.Enums;
using MarriageHall.DTO;
using System.Windows.Forms;
using System;

namespace MarriageHall.GUI
{
    public partial class FrmCustomer : Form
    {
        public Account LoginAccount { get; set; }
        public FrmCustomer(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
        }

        bool isAdd = false;
        bool isEdit = false;
        Customer customer = new Customer();

        private void GetCustomer()
        {
            bool hasId = int.TryParse(txtId.Text, out int id);
            if (hasId)
            {
                customer.Id = id;
            }
            customer.Name = txtName.Text;
            customer.Phone = txtPhone.Text;
            customer.Gender = (GenderEnum)cboGender.SelectedValue;
        }

        private void LoadListCustomer()
        {
            dgvCustomer.DataSource = BLLCustomer.Instance.GetListCustomer();
            cboGender.DataSource = EnumExtension.GetListDescriptions<GenderEnum>();
            cboGender.ValueMember = "Key";
            cboGender.DisplayMember = "Value";
        }

        private void ResetState()
        {
            isAdd = false;
            isEdit = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnBooking.Enabled = true;
        }

        private void Clear()
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
        }

        private void FrmCustomer_Load(object sender, System.EventArgs e)
        {
            LoadListCustomer();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (isAdd)
            {
                ResetState();
                return;
            }
            isAdd = true;
            btnEdit.Enabled = false;
            btnBooking.Enabled = false;
            Clear();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (isEdit)
            {
                ResetState();
                return;
            }
            isEdit = true;
            btnAdd.Enabled = false;
            btnBooking.Enabled = false;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            GetCustomer();
            try
            {
                if (isAdd)
                {
                    if (!BLLCustomer.Instance.Validate(customer))
                    {
                        return;
                    }
                    if (BLLCustomer.Instance.InsertCustomer(customer))
                    {
                        MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
                    }
                }
                if (isEdit)
                {
                    if (!BLLCustomer.Instance.Validate(customer))
                    {
                        return;
                    }
                    if (BLLCustomer.Instance.UpdateCustomer(customer))
                    {
                        MessageBox.Show("Sửa khách hàng thành công", "Thông báo");
                    }
                }
                ResetState();
                Clear();
                LoadListCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCustomer.SelectedCells[0].OwningRow;
            if (!isAdd && !isEdit)
            {
                txtId.Text = row.Cells["Id"].Value.ToString();
            }
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            cboGender.SelectedValue = int.Parse(row.Cells["Gender"].Value.ToString());
        }

        private void txtSearchNameAndPhone_TextChanged(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = BLLCustomer.Instance.SearchCustomerByNameAndPhone(txtSearchNameAndPhone.Text);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            GetCustomer();
            if (customer.Id == 0)
            {
                MessageBox.Show("Khách hàng không hợp lệ!", "Thông báo");
                return;
            }
            FrmBooking frmBooking = new FrmBooking(LoginAccount, customer);
            Hide();
            frmBooking.ShowDialog();
            Show();
        }
    }
}
