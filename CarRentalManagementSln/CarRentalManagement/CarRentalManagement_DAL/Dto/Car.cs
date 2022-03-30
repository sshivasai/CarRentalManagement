using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Dto
{
    public class Car

    {
        [Key]
        [Display(Name = "Car Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Car Model is required")]
        [Display(Name = "Car Model")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Car Category is required")]

        public int CarCategoryId { get; set; }
        [ValidateNever]
        public CarCategory CarCategory { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        public int ManufacturerId { get; set; }
        [ValidateNever]
        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; } = null;

        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Year of Manufacture ")]
        public int Year { get; set; }
        public int Stock { set; get; }


        [Required(ErrorMessage ="Default Price is required")]
        [Display(Name ="Price without any Offers")]
        public decimal DefaultPrice { get; set; }


        [Required(ErrorMessage = "Per Day Price is required")]
        [Display(Name = "Price per Day (1 to 7 days )")]
        public decimal? PricePerDay { get; set; }


        [Required(ErrorMessage = "Per Week is required")]
        [Display(Name = "Price for more than a Week(7 to 15 days )")]
        public decimal? PricePerWeek { get; set; }


        [Required(ErrorMessage = "Per Month Price is required")]
        [Display(Name = "Price for more than 2 Weeks(15 to 30 days )")]
        public decimal? PricePerMonth { get; set; }
        public int? Gears { get; set; }
        public string? Transmission { get; set; }


        public string? Condition { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; } = null;
    }
}
