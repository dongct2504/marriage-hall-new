using MarriageHall.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmStatisticsItem : Form
    {
        public FrmStatisticsItem()
        {
            InitializeComponent();
            lsvItem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvItem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            cboStatisticsItemCategory.DataSource = BLLCategory.Instance.GetListCategory();
            cboStatisticsItemCategory.ValueMember = "Id";
            cboStatisticsItemCategory.DisplayMember = "Name";
        }

        private void FrmStatisticsItem_Load(object sender, EventArgs e)
        {
            LoadStatisticsItem();
        }

        private void LoadStatisticsItem()
        {
            int categoryId = (int)cboStatisticsItemCategory.SelectedValue;
            DateTime date = dtpkStatisticsItem.Value;

            var statisticsItem = BLLItem.Instance.GetStatisticsItem(date, categoryId);

            lsvItem.Items.Clear();
            foreach (DataRow row in statisticsItem.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(row["Id"].ToString());
                listViewItem.SubItems.Add(row["Name"].ToString());
                listViewItem.SubItems.Add(row["TotalQuantity"].ToString());
                lsvItem.Items.Add(listViewItem);
            }
        }

        private void dtpkStatisticsItem_ValueChanged(object sender, EventArgs e)
        {
            LoadStatisticsItem();
        }

        private void cboStatisticsItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatisticsItemCategory.Items.Count > 0)
            {
                bool hasCategoryId = int.TryParse(cboStatisticsItemCategory.SelectedValue.ToString(), out int categoryId);
                if (hasCategoryId)
                {
                    LoadStatisticsItem();
                }
            }
        }
    }
}
