using MarriageHall.BLL;
using MarriageHall.DTO;
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
            LoadListCategory();
            LoadListItem();
            LoadListHall();
        }

        #region category_and_item
        bool isAddCategory = false;
        bool isEditCategory = false;
        bool isAddItem = false;
        bool isEditItem = false;
        Category category = new Category();
        Item item = new Item();

        private void GetCategory()
        {
            category.Id = (int)cboCategory.SelectedValue;
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
            txtItemId.Clear();
            txtItemName.Clear();
            nmItemPrice.Value = 0;
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
            txtItemId.Clear();
            txtItemName.Clear();
            nmItemPrice.Value = 0;
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
                    if (BLLItem.Instance.Validate(item))
                    {
                        if (BLLItem.Instance.InsertItem(item))
                        {
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");
                        }
                    }
                }
                if (isEditItem)
                {
                    if (BLLItem.Instance.Validate(item))
                    {
                        if (BLLItem.Instance.UpdateItem(item))
                        {
                            MessageBox.Show("Sửa sản phẩm thành công", "Thông báo");
                        }
                    }
                }
                cboCategory.SelectedValue = cboItemCategory.SelectedValue;
                ResetStateCategoryAndItem();
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
            txtHallId.Clear();
            txtHallName.Clear();
            nmHallNumberOfTables.Value = 0;
            nmHallPrice.Value = 0;
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
            txtHallId.Clear();
            txtHallName.Clear();
            nmHallNumberOfTables.Value = 0;
            nmHallPrice.Value = 0;
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
                    if (BLLHall.Instance.Validate(hall))
                    {
                        if (BLLHall.Instance.InsertHall(hall))
                        {
                            MessageBox.Show("Thêm sảnh cưới thành công", "Thông báo");
                        }
                    }
                }
                if (isEditHall)
                {
                    if (BLLHall.Instance.Validate(hall))
                    {
                        if (BLLHall.Instance.UpdateHall(hall))
                        {
                            MessageBox.Show("Sửa sảnh cưới thành công", "Thông báo");
                        }
                    }
                }
                ResetStateHall();
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
    }
}
