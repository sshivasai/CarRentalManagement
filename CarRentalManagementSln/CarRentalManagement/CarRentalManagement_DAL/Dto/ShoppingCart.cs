using CarRentalManagement_DAL.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.Dto
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        [ValidateNever]
        public Car Car { get; set; }

        [Range(1, 365, ErrorMessage = "Please Contact Company for Booking period more than a year")]
        //public int? days { get; set; }


        public DateTime PickupDate { get; set; } = DateTime.Today;
        public DateTime ReturnDate { get; set; } = DateTime.Today;

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
        [NotMapped]
        public int? Days { get; set; }
    }
}
