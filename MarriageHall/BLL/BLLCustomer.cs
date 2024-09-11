using MarriageHall.DLL;
using MarriageHall.DTO;
using System.Data;
using System.Text.RegularExpressions;
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

        public Customer GetCustomerByBookingId(int bookingId)
        {
            string query = $"SELECT c.* FROM Customers AS c JOIN Bookings AS b ON c.Id = b.CustomerId AND b.Id = {bookingId}";

            DataTable data = DataProvider.Instance.GetDataTable(query);

            foreach (DataRow row in data.Rows)
            {
                return new Customer(row);
            }

            return null;
        }

        public DataTable SearchCustomerByNameAndPhone(string search)
        {
            string query = $"SELECT * FROM Customers WHERE Name LIKE N'%{search} %' OR Phone LIKE '%{search}%'";

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
            if (!Regex.IsMatch(customer.Phone, @"^0\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoạt không hợp lệ", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
