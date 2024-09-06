using MarriageHall.DLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Data;
using System.Windows.Forms;

namespace MarriageHall.BLL
{
    public class BLLBooking
    {
        private static BLLBooking instance;
        public static BLLBooking Instance
        {
            get { if (instance == null) instance = new BLLBooking(); return instance; }
            private set { instance = value; }
        }

        public BLLBooking() { }

        public DataTable GetListBooking()
        {
            string query = "SELECT * FROM Bookings";

            return DataProvider.Instance.GetDataTable(query);
        }

        public DataTable SearchItemByName(string name)
        {
            string query = $"SELECT * FROM Items WHERE Name LIKE N'%{name}%'";

            return DataProvider.Instance.GetDataTable(query);
        }

        public bool InsertBooking(Booking booking)
        {
            int isPaid = booking.IsPaid ? 1 : 0;
            string query = $"INSERT INTO Bookings (HallId, CustomerId, StaffId, NumberOfPeople, Status, Shift, Note, Discount, TotalPrice, IsPaid, ServiceDate, CreatedAt) VALUES ({booking.HallId}, {booking.CustomerId}, {booking.StaffId}, {booking.NumberOfPeople}, {(int)StatusEnum.New}, {(int)booking.Shift}, '{booking.Note}', {booking.Discount},  {booking.TotalPrice}, {isPaid}, '{booking.ServiceDate.ToString("yyyy-MM-dd")}', '{DateTime.Today.ToString("yyyy-MM-dd")}')";

            return DataProvider.Instance.RunQuery(query);
        }

        public int GetBookingId(int hallId, ShiftEnum shift, DateTime date)
        {
            string query = $"SELECT MAX(Id) AS Id FROM Bookings WHERE HallId = {hallId} AND Shift = {(int)shift} AND ServiceDate = '{date.ToString("yyyy-MM-dd")}'";

            DataTable data = DataProvider.Instance.GetDataTable(query);

            return (int)data.Rows[0]["Id"];
        }

        public bool Validate(Booking booking)
        {
            if (booking.HallId == 0)
            {
                MessageBox.Show("Vui lòng chọn sảnh cưới", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
