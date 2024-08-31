using MarriageHall.BLL;
using MarriageHall.DTO;
using System;
using System.Data;
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

        bool isAddCategory = false;
        bool isEditCategory = false;
        bool isAddItem = false;
        bool isEditItem = false;

        Category category = new Category();
        Item item = new Item();

        #region methods
        private void GetCategory()
        {
            bool hasCategoryId = int.TryParse(txtCategoryId.Text, out int categoryId);
            if (hasCategoryId)
            {
                category.Id = categoryId;
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
            DataRow row = ((DataTable)cboItemCategory.DataSource).Rows[cboItemCategory.SelectedIndex];
            item.CategoryId = (int)row["Id"];
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
            if (cboCategory.SelectedIndex == -1) return;
            dgvItem.DataSource = BLLItem.Instance.GetItemByCategoryId(int.Parse(cboCategory.SelectedValue.ToString()));
        }

        private void ResetState()
        {
            isAddCategory = false;
            isEditCategory = false;
            isAddItem = false;
            isEditItem = false;
            btnAddCategory.Enabled = true;
            btnEditCategory.Enabled = true;
            btnDeleteCategory.Enabled = true;
            btnSaveCategory.Enabled = true;
            btnAddItem.Enabled  = true;
            btnEditItem.Enabled = true;
            btnDeleteItem.Enabled = true;
            btnSaveItem.Enabled = true;
            cboCategory.Enabled = true;
        }
        #endregion

        #region events
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            ResetState();
            LoadListCategory();
            LoadListItem();
        }
        #endregion

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
                ResetState();
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
                ResetState();
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
                    ResetState();
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
                    ResetState();
                }
                LoadListCategory();
            }
            catch (Exception  ex)
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
            txtItemId.Text = row.Cells["Id"].Value.ToString();
            txtItemName.Text = row.Cells["Name"].Value.ToString();
            nmItemPrice.Value = (decimal)row.Cells["Price"].Value;
            cboItemCategory.SelectedIndex = cboCategory.SelectedIndex;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            GetItem();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BLLItem.Instance.DeleteItem(item.Id))
                {
                    MessageBox.Show("Xoá sản phẩm thành công", "Thông báo");
                }
            }
            LoadListItem();
        }

        private void btnResetCategory_Click(object sender, EventArgs e)
        {
            FrmAdmin_Load(sender, e);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (isAddItem)
            {
                ResetState();
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
                ResetState();
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
                    ResetState();
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
                    ResetState();
                }
                LoadListItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
