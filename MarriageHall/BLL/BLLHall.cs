using MarriageHall.DLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
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

        public Hall GetHallByBookingId(int bookingId)
        {
            string query = $"SELECT h.* FROM Halls AS h JOIN Bookings AS b ON h.Id = b.HallId AND b.Id = {bookingId}";

            DataTable data = DataProvider.Instance.GetDataTable(query);

            foreach (DataRow row in data.Rows)
            {
                return new Hall(row);
            }

            return null;
        }

        public DataTable GetHallAvailableByDate(DateTime dateTime)
        {
            var shiftList = EnumExtension.GetListDescriptions<ShiftEnum>();

            string query = $"SELECT * FROM Halls WHERE Id NOT IN (SELECT HallId FROM Bookings WHERE Status = {(int)StatusEnum.New} AND ServiceDate = '{dateTime.ToString("yyyy-MM-dd")}' GROUP BY HallId HAVING COUNT(Shift) = {shiftList.Count})";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable GetShiftUnavailableByDate(int hallId, DateTime dateTime)
        {
            string query = $"SELECT Shift FROM Bookings WHERE HallId = {hallId} AND ServiceDate = '{dateTime.ToString("yyyy-MM-dd")}'";

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
