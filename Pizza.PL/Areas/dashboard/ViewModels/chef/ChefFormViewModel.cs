namespace Pizza.PL.Areas.dashboard.ViewModels.chef
{
    public class ChefFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgName { get; set; }
        public bool IsDeleted { get; set; }


    }
}
