using System.ComponentModel.DataAnnotations;

namespace Pizza.PL.Areas.dashboard.ViewModels.chef
{
    public class ChefFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rank is Required")]
      
        public string Rank { get; set; }

        [Required(ErrorMessage = " Image is Required")]
        public IFormFile Image { get; set; }
        public string? ImgName { get; set; }
        public bool IsDeleted { get; set; }


    }
}
