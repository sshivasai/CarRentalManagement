using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Payment
    {
        [Key]
        
        public string PaymentId { get; set; }

        
        public decimal? PaymentAmount { get; set; }

        
        public string PaymentType { get; set; }

       
        public UserDto User { get; set; }
       
        public bool PaymentStatus { get; set; }
        

    }
}