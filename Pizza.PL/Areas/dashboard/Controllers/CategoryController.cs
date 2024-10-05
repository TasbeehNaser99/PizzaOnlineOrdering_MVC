using Microsoft.AspNetCore.Mvc;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
