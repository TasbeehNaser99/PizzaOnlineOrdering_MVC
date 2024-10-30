namespace Pizza.PL.Areas.dashboard.ViewModels.pizza
{
    public class PizzaDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public double Price { get; set; }
        public string ImgName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
