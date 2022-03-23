using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Transmition
    {
        [Key]
        public int carID;
        public String geartype;
    }
}