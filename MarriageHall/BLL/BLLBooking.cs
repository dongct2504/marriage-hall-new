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

        public DataTable GetPageBooking(DateTime dateTime, int pageIndex)
        {
            int limit = 1;
            string query = $"SELECT b.*, c.Name AS CustomerName, c.Phone AS CustomerPhone FROM Bookings b JOIN Customers c ON b.CustomerId = c.Id WHERE ServiceDate = '{dateTime.ToString("yyyy-MM-dd")}' ORDER BY Id OFFSET {(pageIndex - 1) * limit} ROWS FETCH NEXT {limit} ROWS ONLY";

            return DataProvider.Instance.GetDataTable(query);
        }
        public int GetTotalPageBooking(DateTime dateTime)
        {
            int limit = 1;
            string query = $"SELECT COUNT(Id) AS Count FROM Bookings WHERE ServiceDate = '{dateTime.ToString("yyyy-MM-dd")}'";

            DataTable data = DataProvider.Instance.GetDataTable(query);
            int count = (int)data.Rows[0]["Count"];
            if (count == 0)
            {
                return 1;
            }

            return count % limit == 0 ? count / limit : count / limit + 1;
        }

        public bool InsertBooking(Booking booking)
        {
            int isPaid = booking.IsPaid ? 1 : 0;
            string query = $"INSERT INTO Bookings (HallId, CustomerId, StaffId, NumberOfPeople, Status, Shift, Note, Discount, TotalPrice, IsPaid, ServiceDate, CreatedAt) VALUES ({booking.HallId}, {booking.CustomerId}, {booking.StaffId}, {booking.NumberOfPeople}, {(int)StatusEnum.New}, {(int)booking.Shift}, '{booking.Note}', {booking.Discount},  {booking.TotalPrice}, {isPaid}, '{booking.ServiceDate.ToString("yyyy-MM-dd")}', '{DateTime.Today.ToString("yyyy-MM-dd")}')";

            return DataProvider.Instance.RunQuery(query);
        }

        public bool UpdateBooking(int id, int isPaid, int status)
        {
            string query = $"UPDATE Bookings SET IsPaid = {isPaid}, Status = {status} WHERE Id = {id}";

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
