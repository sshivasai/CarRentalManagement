using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement_DAL.Dto
{
    public class CarCategory
    {
        [Key]
        [Display(Name ="Category ID")]
        public int Id { get; set; }

        [Display(Name = "Name of Category ")]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }

       
        public string? Description { get; set; } = null;
    }
}
