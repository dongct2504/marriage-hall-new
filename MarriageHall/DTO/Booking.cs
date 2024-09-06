using MarriageHall.DTO.Enums;
using System;

namespace MarriageHall.DTO
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int HallId { get; set; }
        public StatusEnum Status { get; set; }
        public ShiftEnum Shift { get; set; }
        public int NumberOfPeople { get; set; }
        public string Note { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset ServiceDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
