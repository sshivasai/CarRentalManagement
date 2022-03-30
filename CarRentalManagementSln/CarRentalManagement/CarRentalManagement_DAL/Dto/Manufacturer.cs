using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Dto
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name of the Brand / Manufacturer")]
        public string Name { get; set; }
    }
}
