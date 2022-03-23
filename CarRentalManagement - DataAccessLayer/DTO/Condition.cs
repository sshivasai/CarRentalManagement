using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Condition
    {
        [Key]
        public int CarID;
        public string conditionName;
    }
}