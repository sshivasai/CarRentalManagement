using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        public UserDto OrderedBy { get; set; }
        
        public CarDto CarDetails { get; set; }
        
        public Payment PaymentDetails { get; set; }

        public Status OrderStatus { get; set; }

    }
}