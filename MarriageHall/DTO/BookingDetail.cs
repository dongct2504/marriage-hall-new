namespace MarriageHall.DTO
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public int BookingId { get; set; }
    }
}
