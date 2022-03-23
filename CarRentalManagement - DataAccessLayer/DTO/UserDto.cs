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

        [Required]
        [StringLength(255)]
        public string FName { get; set; }
        [Required]
        [StringLength(255)]
        public string LName { get; set; }
        [Required,StringLength(255)]
        private string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public IDProof KycDetails { get; set; }
        //[Min18YearsIfAMember]
        [Range(18, 100)]
        public int Age { get; set; }
        public List<Order>? OrdersPlaced { get; set; }
    }
}
