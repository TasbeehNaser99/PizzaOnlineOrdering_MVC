using System.ComponentModel.DataAnnotations;

namespace Pizza.PL.Areas.dashboard.ViewModels.drink
{
    public class DrinkFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
      
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(0, double.MaxValue, ErrorMessage = "The value cannot be negative.")]
        public double Price { get; set; }

        [Required(ErrorMessage = " Image is Required")]
        public IFormFile Image { get; set; }
        public string? ImgName { get; set; }
        public bool IsDeleted { get; set; }


    }
}
