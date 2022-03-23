using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Condition
    {
        [Key]
        public int CarID { get; set; }
        public string conditionName { get; set; }
    }
}