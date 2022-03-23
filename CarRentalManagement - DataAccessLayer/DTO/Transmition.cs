using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Transmition
    {
        [Key]
        public int CarID { get; set; }
        public String GearType { get; set; }
    }
}