using CarRentalManagement___DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.Repository.NewFolder
{
    public class AdminDto
    {
        [Key]
        [Required(ErrorMessage ="Admin Id is required")]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255)]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(255)]
        public string LName { get; set; }
        [Required(ErrorMessage = "Required Field"), DataType(DataType.Password, ErrorMessage = "Please set a valid password")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Enter a valid Phone Number")]
        public string PhoneNumber { get; set; }
       
        public ICollection<Order>? OrderDetails { get; set; }
  
    }
}
