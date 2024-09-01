using MarriageHall.DLL;
using MarriageHall.DTO;
using System.Data;
using System.Windows.Forms;

namespace MarriageHall.BLL
{
    public class BLLHall
    {
        private static BLLHall instance;
        public static BLLHall Instance
        {
            get { if (instance == null) instance = new BLLHall(); return instance; }
            private set { instance = value; }
        }

        public BLLHall() { }

        public DataTable GetListHall()
        {
            string query = "SELECT * FROM Halls";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable SearchHallByName(string name)
        {
            string query = $"SELECT * FROM Halls WHERE Name LIKE N'%{name}%'";

            return DataProvider.Instance.GetDataTable(query);
        }

        public bool InsertHall(Hall hall)
        {
            string query = $"INSERT INTO Halls (Name, NumberOfTables, Price) VALUES (N'{hall.Name}', {hall.NumberOfTables}, {hall.Price})";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool UpdateHall(Hall hall)
        {
            string query = $"UPDATE Halls SET Name = N'{hall.Name}', NumberOfTables = {hall.NumberOfTables}, Price = {hall.Price} WHERE Id = {hall.Id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool DeleteHall(int id)
        {
            string query = $"DELETE Halls WHERE Id = {id}";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool Validate(Hall hall)
        {
            if (hall.Name.Equals(""))
            {
                MessageBox.Show("Tên sảnh cưới không được để trống", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
