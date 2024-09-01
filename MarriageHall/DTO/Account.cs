﻿using MarriageHall.DTO.Enums;

namespace MarriageHall.DTO
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public GenderEnum Gender { get; set; }
        public string Password { get; set; } = "";
        public PermissionEnum Permission { get; set; }
    }
}
