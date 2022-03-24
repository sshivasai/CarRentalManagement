using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class UserDto
    {
        [Key]
        public int UserId {get; set;}
        
        public string Password { get; set; }
      
        public string FName { get; set; }
        
        public string LName { get; set; }
       
        public string Email { get; set; }
       
        public string PhoneNumber { get; set; }
      
        public IDProof KycDetails { get; set; }
        //[Min18YearsIfAMember]
        
        public int Age { get; set; }
        public ICollection<Order>? OrdersPlaced { get; set; }
    }
}
