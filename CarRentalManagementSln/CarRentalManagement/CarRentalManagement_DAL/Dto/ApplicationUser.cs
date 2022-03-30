using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Dto
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="Name is Required")]
        public String Name { get; set; }

        [Display(Name ="ID Proof (PAN CARD)")]
        [Required(ErrorMessage ="ID Proof is Mandatory")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string IDProof { get; set; }


        [Required(ErrorMessage ="Age is Required")]
        [Range(18,100,ErrorMessage ="Age should be between 18 and 100 only")]
        public int Age { get; set; }

    }
}
