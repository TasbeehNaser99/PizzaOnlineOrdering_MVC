namespace Pizza.PL.Areas.dashboard.ViewModels.pizza
{
    public class PizzaFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgName { get; set; }
        public bool IsDeleted { get; set; }


    }
}
