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

        
        public string Name { get; set; }

        
        //        [MinMaxCarAge]
        public int year { get; set; }

        public CarTypeDto CarType { get; set; }

        
        public int Stock { set; get; }
        
        public decimal DailyPrice { get; set; }
        
        public decimal DayDelayPrice { get; set; }
      
        public Condition Condition { get; set; }
    }
}
