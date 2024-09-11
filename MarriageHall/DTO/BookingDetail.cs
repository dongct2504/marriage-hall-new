using System.Data;

namespace MarriageHall.DTO
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int BookingId { get; set; }
        public decimal TotalPrice
        {
            get { return Quantity * Price; }
        }

        public BookingDetail()
        {
        }

        public BookingDetail(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.BookingId = (int)row["BookingId"];
            this.ItemId = (int)row["ItemId"];
            this.Quantity = (int)row["Quantity"];
            this.Price = (decimal)row["Price"];
            this.ItemName = row["ItemName"].ToString();
        }
    }
}
