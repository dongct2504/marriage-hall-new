﻿using MarriageHall.DTO.Enums;
using System;
using System.Data;

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
        public int NumberOfTables { get; set; }
        public string Note { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset ServiceDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Booking()
        {
            
        }

        public Booking(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.CustomerId = (int)row["CustomerId"];
            this.StaffId = (int)row["StaffId"];
            this.HallId = (int)row["HallId"];
            this.Status = (StatusEnum)int.Parse(row["Status"].ToString());
            this.Shift = (ShiftEnum)int.Parse(row["Shift"].ToString());
            this.NumberOfTables = int.Parse(row["NumberOfTables"].ToString());
            this.Note = row["Note"].ToString();
            this.Discount = (decimal)row["Discount"];
            this.TotalPrice = (decimal)row["TotalPrice"];
            this.IsPaid = (bool)row["IsPaid"];
            this.ServiceDate = (DateTimeOffset)row["ServiceDate"];
            this.CreatedAt = (DateTimeOffset)row["CreatedAt"];
        }
    }
}
