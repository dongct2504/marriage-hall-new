using MarriageHall.DLL;
using MarriageHall.DTO;
using System.Data;
using System.Windows.Forms;

namespace MarriageHall.BLL
{
    public class BLLItem
    {
        private static BLLItem instance;
        public static BLLItem Instance
        {
            get { if (instance == null) instance = new BLLItem(); return instance; }
            private set { instance = value; }
        }

        public BLLItem() { }

        public DataTable GetListItem()
        {
            string query = "SELECT * FROM Items";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable GetItemById(int id)
        {
            string query = $"SELECT * FROM Items WHERE Id = {id}";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable GetItemByCategoryId(int categoryId)
        {
            string query = $"SELECT * FROM Items WHERE CategoryId = {categoryId}";

            return DataProvider.Instance.GetDataTable(query);
        }

        public bool InsertItem(Item item)
        {
            string query = $"INSERT INTO Items (Name, CategoryId, Price) VALUES (N'{item.Name}', {item.CategoryId}, {item.Price})";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool UpdateItem(Item item)
        {
            string query = $"UPDATE Items SET Name = '{item.Name}', CategoryId = {item.CategoryId}, Price = {item.Price} WHERE Id = {item.Id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool DeleteItem(int id)
        {
            string query = $"DELETE Items WHERE Id = {id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool Validate(Item item)
        {
            if (item.Name.Equals(""))
            {
                MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
