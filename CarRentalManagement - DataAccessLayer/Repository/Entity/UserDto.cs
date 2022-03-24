using CarRentalManagement___DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.Repository.Entity
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(255)]
        public string FName { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [StringLength(255)]
        public string LName { get; set; }
        [Required(ErrorMessage = "Required Field"), DataType(DataType.Password,ErrorMessage ="Please set a valid password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter a valid Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter a valid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Required Field")]
        public IDProof KycDetails { get; set; }
        //[Min18YearsIfAMember]
        [Range(18, 100,ErrorMessage ="Age Should be Betwen 18 and 100")]

        public int Age { get; set; }
        public List<Order>? OrdersPlaced { get; set; }
    }
}
