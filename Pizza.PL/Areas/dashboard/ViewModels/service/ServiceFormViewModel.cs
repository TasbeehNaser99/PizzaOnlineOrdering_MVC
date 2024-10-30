namespace Pizza.PL.Areas.dashboard.ViewModels.service
{
    public class ServiceFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Image { get; set; }
        public string? ImgName { get; set; }
        public bool IsDeleted { get; set; }


    }
}
