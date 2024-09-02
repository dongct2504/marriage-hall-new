using MarriageHall.DTO.Enums;
using System.Data;

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

        public Account()
        {
        }

        public Account(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.UserName = row["UserName"].ToString();
            this.Name = row["Name"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Gender = (GenderEnum)int.Parse(row["Gender"].ToString());
            this.Permission = (PermissionEnum)int.Parse(row["Permission"].ToString());
        }
    }
}
