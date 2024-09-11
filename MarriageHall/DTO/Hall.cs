using MarriageHall.DTO.Enums;
using System.Data;

namespace MarriageHall.DTO
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTables { get; set; }
        public decimal Price { get; set; }

        public Hall()
        {
        }

        public Hall(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.NumberOfTables = int.Parse(row["NumberOfTables"].ToString());
            this.Price = (decimal)row["Price"];
        }
    }
}
