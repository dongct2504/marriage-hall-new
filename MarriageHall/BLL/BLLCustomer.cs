using MarriageHall.DLL;
using MarriageHall.DTO;
using System.Data;
using System.Windows.Forms;

namespace MarriageHall.BLL
{
    public class BLLCustomer
    {
        private static BLLCustomer instance;
        public static BLLCustomer Instance
        {
            get { if (instance == null) instance = new BLLCustomer(); return instance; }
            private set { instance = value; }
        }

        public BLLCustomer() { }

        public DataTable GetListCustomer()
        {
            string query = "SELECT * FROM Customers";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable SearchCustomerByName(string name)
        {
            string query = $"SELECT * FROM Customers WHERE Name LIKE N'%{name}%'";

            return DataProvider.Instance.GetDataTable(query);
        }

        public bool InsertCustomer(Customer customer)
        {
            string query = $"INSERT INTO Customers (Name, Phone, Gender) VALUES (N'{customer.Name}', '{customer.Phone}', {(int)customer.Gender})";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool UpdateCustomer(Customer customer)
        {
            string query = $"UPDATE Customers SET Name = N'{customer.Name}', Phone = '{customer.Phone}', Gender = {(int)customer.Gender} WHERE Id = {customer.Id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool DeleteCustomer(int id)
        {
            string query = $"DELETE Customers WHERE Id = {id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool Validate(Customer customer)
        {
            if (customer.Name.Equals(""))
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
