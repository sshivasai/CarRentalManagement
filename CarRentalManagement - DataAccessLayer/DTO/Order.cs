using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public UserDto OrderedBy { get; set; }
        [Required]
        public CarDto CarDetails { get; set; }
        [Required]
        public Payment PaymentDetails { get; set; }

        public Status OrderStatus { get; set; }

    }
}