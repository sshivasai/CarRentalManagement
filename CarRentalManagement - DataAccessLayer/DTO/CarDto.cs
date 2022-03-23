using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class CarDto
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        //        [MinMaxCarAge]
        public int year { get; set; }

        [Required]
        public CarTypeDto CarType { get; set; }

        [Required]
        [Range(0, 20)]
        public int Stock { set; get; }
        [Required]
        public decimal DailyPrice { get; set; }
        [Required]
        public decimal DayDelayPrice { get; set; }
        [Required]
        public Condition Condition { get; set; }
    }
}
