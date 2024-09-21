using MarriageHall.BLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmAdmin : Form
    {
        BindingSource categoryList = new BindingSource();
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            LoadRevenueChart();
            LoadListCategory();
            LoadListItem();
            LoadListHall();
            LoadListAccount();
            LoadListCustomer();
        }

        #region revenue
        private void LoadRevenueChart()
        {
            foreach (var series in revenueChart.Series)
            {
                series.Points.Clear();
            }
            DateTime dateTimeRevenue = dtpkRevenue.Value;
            var startDate = new DateTime(dateTimeRevenue.Year, dateTimeRevenue.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1); 
            Random rnd = new Random();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                revenueChart.Series["Doanh thu"].Points.AddXY(date.ToString("dd"), BLLBooking.Instance.GetRevenueByDate(date) / 1000000);

            }
        }

        private void dtpkRevenue_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueChart();
        }
        #endregion

        #region category_and_item
        bool isAddCategory = false;
        bool isEditCategory = false;
        bool isAddItem = false;
        bool isEditItem = false;
        Category category = new Category();
        Item item = new Item();

        private void GetCategory()
        {
            if (cboCategory.Items.Count > 0)
            {
                bool hasCategoryId = int.TryParse(cboCategory.SelectedValue.ToString(), out int categoryId);
                if (hasCategoryId)
                {
                    category.Id = categoryId;
                }
            }
            category.Name = txtCategoryName.Text;
        }

        private void GetItem()
        {
            bool hasItemId = int.TryParse(txtItemId.Text, out int itemId);
            if (hasItemId)
            {
                item.Id = itemId;
            }
            item.Name = txtItemName.Text;
            item.CategoryId = (int)cboItemCategory.SelectedValue;
            item.Price = nmItemPrice.Value;
        }

        private void LoadListCategory()
        {
            cboCategory.DataSource = BLLCategory.Instance.GetListCategory();
            cboCategory.ValueMember = "Id";
            cboCategory.DisplayMember = "Name";
            txtCategoryId.DataBindings.Clear();
            txtCategoryId.DataBindings.Add(new Binding("Text", cboCategory.DataSource, "Id"));
            txtCategoryName.DataBindings.Clear();
            txtCategoryName.DataBindings.Add(new Binding("Text", cboCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cboItemCategory.DataSource = BLLCategory.Instance.GetListCategory();
            cboItemCategory.ValueMember = "Id";
            cboItemCategory.DisplayMember = "Name";
        }

        private void LoadListItem()
        {
            GetCategory();
            dgvItem.DataSource = BLLItem.Instance.GetItemByCategoryId(category.Id);
        }

        private void ResetStateCategoryAndItem()
        {
            isAddCategory = false;
            isEditCategory = false;
            isAddItem = false;
            isEditItem = false;
            btnAddCategory.Enabled = true;
            btnEditCategory.Enabled = true;
            btnDeleteCategory.Enabled = true;
            btnSaveCategory.Enabled = true;
            btnAddItem.Enabled = true;
            btnEditItem.Enabled = true;
            btnDeleteItem.Enabled = true;
            btnSaveItem.Enabled = true;
            cboCategory.Enabled = true;
        }

        private void ClearItem()
        {
            txtItemId.Clear();
            txtItemName.Clear();
            nmItemPrice.Value = 0;
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            GetCategory();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLCategory.Instance.DeleteCategory(category.Id))
                {
                    MessageBox.Show("Xóa thể loại thành công", "Thông báo");
                }
            }
            LoadListCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (isAddCategory)
            {
                ResetStateCategoryAndItem();
                return;
            }
            isAddCategory = true;
            cboCategory.Enabled = false;
            btnEditCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            btnAddItem.Enabled = false;
            btnEditItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnSaveItem.Enabled = false;
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (isEditCategory)
            {
                ResetStateCategoryAndItem();
                return;
            }
            isEditCategory = true;
            cboCategory.Enabled = false;
            btnAddCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            btnAddItem.Enabled = false;
            btnEditItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnSaveItem.Enabled = false;
            txtCategoryName.Focus();
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            GetCategory();
            try
            {
                if (isAddCategory)
                {
                    if (BLLCategory.Instance.Validate(category))
                    {
                        if (BLLCategory.Instance.InsertCategory(category))
                        {
                            MessageBox.Show("Thêm thể loại thành công", "Thông báo");
                        }
                    }
                    ResetStateCategoryAndItem();
                }
                if (isEditCategory)
                {
                    if (BLLCategory.Instance.Validate(category))
                    {
                        if (BLLCategory.Instance.UpdateCategory(category))
                        {
                            MessageBox.Show("Sửa thể loại thành công", "Thông báo");
                        }
                    }
                    ResetStateCategoryAndItem();
                }
                LoadListCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListItem();
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvItem.SelectedCells[0].OwningRow;
            if (!isAddItem && !isEditItem)
            {
                txtItemId.Text = row.Cells["Id"].Value.ToString();
            }
            txtItemName.Text = row.Cells["Name"].Value.ToString();
            nmItemPrice.Value = (decimal)row.Cells["Price"].Value;
            cboItemCategory.SelectedValue = row.Cells["CategoryId"].Value;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            GetItem();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLItem.Instance.DeleteItem(item.Id))
                {
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo");
                }
            }
            LoadListItem();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (isAddItem)
            {
                ResetStateCategoryAndItem();
                return;
            }
            isAddItem = true;
            btnAddCategory.Enabled = false;
            btnEditCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            btnSaveCategory.Enabled = false;
            btnEditItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            ClearItem();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (isEditItem)
            {
                ResetStateCategoryAndItem();
                return;
            }
            isEditItem = true;
            btnAddCategory.Enabled = false;
            btnEditCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            btnSaveCategory.Enabled = false;
            btnAddItem.Enabled = false;
            btnDeleteItem.Enabled = false;
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            GetItem();
            try
            {
                if (isAddItem)
                {
                    if (!BLLItem.Instance.Validate(item))
                    {
                        return;
                    }
                    if (BLLItem.Instance.InsertItem(item))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");
                    }
                }
                if (isEditItem)
                {
                    if (!BLLItem.Instance.Validate(item))
                    {
                        return;
                    }
                    if (BLLItem.Instance.UpdateItem(item))
                    {
                        MessageBox.Show("Sửa sản phẩm thành công", "Thông báo");
                    }
                }
                cboCategory.SelectedValue = cboItemCategory.SelectedValue;
                ResetStateCategoryAndItem();
                ClearItem();
                LoadListItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemSearchName_TextChanged(object sender, EventArgs e)
        {
            dgvItem.DataSource = BLLItem.Instance.SearchItemByName(txtItemSearchName.Text);
        }

        private void btnStatisticsItem_Click(object sender, EventArgs e)
        {
            FrmStatisticsItem frmStatisticsItem = new FrmStatisticsItem();
            frmStatisticsItem.ShowDialog();
        }
        #endregion

        #region hall
        bool isAddHall = false;
        bool isEditHall = false;
        Hall hall = new Hall();

        private void GetHall()
        {
            bool hasHallId = int.TryParse(txtHallId.Text, out int hallId);
            if (hasHallId)
            {
                hall.Id = hallId;
            }
            hall.Name = txtHallName.Text;
            hall.NumberOfTables = (int)nmHallNumberOfTables.Value;
            hall.Price = nmHallPrice.Value;
        }

        private void LoadListHall()
        {
            dgvHall.DataSource = BLLHall.Instance.GetListHall();
        }

        private void ResetStateHall()
        {
            isAddHall = false;
            isEditHall = false;
            btnAddHall.Enabled = true;
            btnEditHall.Enabled = true;
            btnDeleteHall.Enabled = true;
        }

        private void ClearHall()
        {
            txtHallId.Clear();
            txtHallName.Clear();
            nmHallNumberOfTables.Value = 0;
            nmHallPrice.Value = 0;
        }

        private void bthDeleteHall_Click(object sender, EventArgs e)
        {
            GetHall();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLHall.Instance.DeleteHall(hall.Id))
                {
                    MessageBox.Show("Xóa sảnh cưới thành công", "Thông báo");
                }
            }
            ClearHall();
            LoadListHall();
        }

        private void btnAddHall_Click(object sender, EventArgs e)
        {
            if (isAddHall)
            {
                ResetStateHall();
                return;
            }
            isAddHall = true;
            btnEditHall.Enabled = false;
            btnDeleteHall.Enabled = false;
            ClearHall();
            txtHallName.Focus();
        }

        private void btnEditHall_Click(object sender, EventArgs e)
        {
            if (isEditHall)
            {
                ResetStateHall();
                return;
            }
            isEditHall = true;
            btnAddHall.Enabled = false;
            btnDeleteHall.Enabled = false;
        }

        private void btnSaveHall_Click(object sender, EventArgs e)
        {
            GetHall();
            try
            {
                if (isAddHall)
                {
                    if (!BLLHall.Instance.Validate(hall))
                    {
                        return;
                    }
                    if (BLLHall.Instance.InsertHall(hall))
                    {
                        MessageBox.Show("Thêm sảnh cưới thành công", "Thông báo");
                    }
                }
                if (isEditHall)
                {
                    if (!BLLHall.Instance.Validate(hall))
                    {
                        return;
                    }
                    if (BLLHall.Instance.UpdateHall(hall))
                    {
                        MessageBox.Show("Sửa sảnh cưới thành công", "Thông báo");
                    }
                }
                ResetStateHall();
                ClearHall();
                LoadListHall();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHallSearchName_TextChanged(object sender, EventArgs e)
        {
            dgvHall.DataSource = BLLHall.Instance.SearchHallByName(txtHallSearchName.Text);
        }

        private void dgvHall_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvHall.SelectedCells[0].OwningRow;
            if (!isAddHall && !isEditHall)
            {
                txtHallId.Text = row.Cells["Id"].Value.ToString();
            }
            txtHallName.Text = row.Cells["Name"].Value.ToString();
            nmHallNumberOfTables.Value = int.Parse(row.Cells["NumberOfTables"].Value.ToString());
            nmHallPrice.Value = (decimal)row.Cells["Price"].Value;
        }
        #endregion

        #region account
        bool isAddAccount = false;
        bool isEditAccount = false;
        Account account = new Account();

        private void GetAccount()
        {
            bool hasAccountId = int.TryParse(txtAccountId.Text, out int accountId);
            if (hasAccountId)
            {
                account.Id = accountId;
            }
            account.UserName = txtAccountUserName.Text;
            account.Name = txtAccountName.Text;
            account.Phone = txtAccountPhone.Text;
            account.Gender = (GenderEnum)cboAccountGender.SelectedValue;
            account.Permission = (PermissionEnum)cboAccountPermission.SelectedValue;
        }

        private void LoadListAccount()
        {
            dgvAccount.DataSource = BLLAccount.Instance.GetListAccount();
            cboAccountGender.DataSource = EnumExtension.GetListDescriptions<GenderEnum>();
            cboAccountGender.ValueMember = "Key";
            cboAccountGender.DisplayMember = "Value";
            cboAccountPermission.DataSource = EnumExtension.GetListDescriptions<PermissionEnum>();
            cboAccountPermission.ValueMember = "Key";
            cboAccountPermission.DisplayMember = "Value";
        }

        private void ResetStateAccount()
        {
            isAddAccount = false;
            isEditAccount = false;
            btnAddAccount.Enabled = true;
            btnEditAccount.Enabled = true;
            btnDeleteAccount.Enabled = true;
            btnResetPassword.Enabled = true;
            txtAccountUserName.ReadOnly = true;
        }

        private void ClearAccount()
        {
            txtAccountId.Clear();
            txtAccountUserName.Clear();
            txtAccountName.Clear();
            txtAccountPhone.Clear();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            GetAccount();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLAccount.Instance.DeleteAccount(account.Id))
                {
                    MessageBox.Show("Xóa tài khoản thành công", "Thông báo");
                }
            }
            ClearAccount();
            LoadListAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (isAddAccount)
            {
                ResetStateAccount();
                return;
            }
            isAddAccount = true;
            btnEditAccount.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnResetPassword.Enabled = false;
            ClearAccount();
            txtAccountUserName.ReadOnly = false;
            txtAccountUserName.Focus();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            if (isEditAccount)
            {
                ResetStateAccount();
                return;
            }
            isEditAccount = true;
            btnAddAccount.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnResetPassword.Enabled = false;
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            GetAccount();
            try
            {
                if (isAddAccount)
                {
                    if (!BLLAccount.Instance.Validate(account))
                    {
                        return;
                    }
                    if (BLLAccount.Instance.InsertAccount(account))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo");
                    }
                }
                if (isEditAccount)
                {
                    if (!BLLAccount.Instance.Validate(account))
                    {
                        return;
                    }
                    if (BLLAccount.Instance.UpdateAccount(account))
                    {
                        MessageBox.Show("Sửa tài khoản thành công", "Thông báo");
                    }
                }
                ResetStateAccount();
                ClearAccount();
                LoadListAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvAccount.SelectedCells[0].OwningRow;
            if (!isAddAccount && !isEditAccount)
            {
                txtAccountId.Text = row.Cells["Id"].Value.ToString();
                txtAccountUserName.Text = row.Cells["UserName"].Value.ToString();
            }
            txtAccountName.Text = row.Cells["Name"].Value.ToString();
            txtAccountPhone.Text = row.Cells["Phone"].Value.ToString();
            cboAccountGender.SelectedValue = int.Parse(row.Cells["Gender"].Value.ToString());
            cboAccountPermission.SelectedValue = int.Parse(row.Cells["Permission"].Value.ToString());
        }

        private void txtAccountSearchName_TextChanged(object sender, EventArgs e)
        {
            dgvAccount.DataSource = BLLAccount.Instance.SearchAccountByNameAndPhone(txtAccountSearchNameAndPhone.Text);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            GetAccount();
            if (BLLAccount.Instance.ChangePassword(account.Id, "1"))
            {
                MessageBox.Show($"Reset mật khẩu tài khoản {account.UserName} thành công", "Thông báo");
            }
        }
        #endregion

        #region customer
        bool isAddCustomer = false;
        bool isEditCustomer = false;
        Customer customer = new Customer();

        private void GetCustomer()
        {
            bool hasCustomerId = int.TryParse(txtCustomerId.Text, out int customerId);
            if (hasCustomerId)
            {
                customer.Id = customerId;
            }
            customer.Name = txtCustomerName.Text;
            customer.Phone = txtCustomerPhone.Text;
            customer.Gender = (GenderEnum)cboCustomerGender.SelectedValue;
        }

        private void LoadListCustomer()
        {
            dgvCustomer.DataSource = BLLCustomer.Instance.GetListCustomer();
            cboCustomerGender.DataSource = EnumExtension.GetListDescriptions<GenderEnum>();
            cboCustomerGender.ValueMember = "Key";
            cboCustomerGender.DisplayMember = "Value";
        }

        private void ResetStateCustomer()
        {
            isAddCustomer = false;
            isEditCustomer = false;
            btnAddCustomer.Enabled = true;
            btnEditCustomer.Enabled = true;
            btnDeleteCustomer.Enabled = true;
        }

        private void ClearCustomer()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            GetCustomer();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLCustomer.Instance.DeleteCustomer(customer.Id))
                {
                    MessageBox.Show("Xóa khách hàng thành công", "Thông báo");
                }
            }
            ClearCustomer();
            LoadListCustomer();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (isAddCustomer)
            {
                ResetStateCustomer();
                return;
            }
            isAddCustomer = true;
            btnEditCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
            ClearCustomer();
            txtCustomerName.Focus();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (isEditAccount)
            {
                ResetStateCustomer();
                return;
            }
            isEditAccount = true;
            btnAddCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            GetCustomer();
            try
            {
                if (isAddCustomer)
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
                if (isEditCustomer)
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
                ResetStateCustomer();
                ClearCustomer();
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
            if (!isAddCustomer && !isEditCustomer)
            {
                txtCustomerId.Text = row.Cells["Id"].Value.ToString();
            }
            txtCustomerName.Text = row.Cells["Name"].Value.ToString();
            txtCustomerPhone.Text = row.Cells["Phone"].Value.ToString();
            cboCustomerGender.SelectedValue = int.Parse(row.Cells["Gender"].Value.ToString());
        }

        private void txtCustomerSearchName_TextChanged(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = BLLCustomer.Instance.SearchCustomerByNameAndPhone(txtCustomerSearchNameAndPhone.Text);
        }
        #endregion
    }
}
