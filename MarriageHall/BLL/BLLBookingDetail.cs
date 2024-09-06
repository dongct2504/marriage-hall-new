using MarriageHall.DLL;
using MarriageHall.DTO;

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
    }
}
