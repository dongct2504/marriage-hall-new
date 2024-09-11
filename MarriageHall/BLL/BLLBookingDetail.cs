using MarriageHall.DLL;
using MarriageHall.DTO;
using System.Collections.Generic;
using System.Data;

namespace MarriageHall.BLL
{
    public class BLLBookingDetail
    {
        private static BLLBookingDetail instance;
        public static BLLBookingDetail Instance
        {
            get { if (instance == null) instance = new BLLBookingDetail(); return instance; }
            private set { instance = value; }
        }

        public BLLBookingDetail() { }

        public bool InsertBookingDetail(BookingDetail bookingDetail)
        {
            string query = $"INSERT INTO BookingDetail (ItemId, BookingId, Quantity, Price) VALUES ({bookingDetail.ItemId}, {bookingDetail.BookingId}, {bookingDetail.Quantity}, {bookingDetail.Price})";

            return DataProvider.Instance.RunQuery(query);
        }

        public List<BookingDetail> GetListBookingDetailByBookingId(int bookingId)
        {
            List<BookingDetail> listBookingDetail = new List<BookingDetail>();

            string query = $"SELECT bd.*, i.Id AS ItemId, i.Name AS ItemName FROM BookingDetail AS bd JOIN Items AS i ON bd.ItemId = i.Id WHERE bd.BookingId = {bookingId}";

            DataTable data = DataProvider.Instance.GetDataTable(query);

            foreach (DataRow row in data.Rows)
            {
                BookingDetail bookingDetail = new BookingDetail(row);
                listBookingDetail.Add(bookingDetail);
            }

            return listBookingDetail;
        }
    }
}
