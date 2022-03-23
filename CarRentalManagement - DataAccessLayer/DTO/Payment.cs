using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Payment
    {
        [Key]
        
        public string PaymentId { get; set; }

        [Required]
        public decimal? PaymentAmount { get; set; }

        [Required]
        public string PaymentType { get; set; }

        [Required]
        public UserDto User { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }
        [Required]
        public Order OrderDetails { get; set; } 

    }
}