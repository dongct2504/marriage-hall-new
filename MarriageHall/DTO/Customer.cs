using MarriageHall.DTO.Enums;
using System.Data;

namespace MarriageHall.DTO
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public GenderEnum Gender { get; set; }

        public Customer()
        {
        }

        public Customer(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Gender = (GenderEnum)int.Parse(row["Gender"].ToString());
        }
    }
}
