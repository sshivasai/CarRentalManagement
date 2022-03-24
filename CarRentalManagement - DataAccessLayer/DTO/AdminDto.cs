using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class AdminDto
    {
        [Key]
        public int AdminId { get; set; }

      
        public string FName { get; set; }
       
        public string LName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public ICollection<Order>? OrderDetails { get; set; }
    }
}
