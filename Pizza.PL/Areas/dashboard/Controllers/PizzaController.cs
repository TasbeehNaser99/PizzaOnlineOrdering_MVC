using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.pizza;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    public class PizzaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PizzaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var pizza = context.Pizzas.ToList();
            var piz = mapper.Map<IEnumerable<PizzaIndex>>(pizza);
            return View("Index",piz);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PizzaFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var pizza = mapper.Map<PizzaType>(vm);
            context.Add(pizza);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var pizza = context.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(mapper.Map<PizzaDetails>(pizza));
        }
        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var pizza = context.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            FilesSetting.DeleteFile(pizza.ImgName, "Img");
            context.Pizzas.Remove(pizza);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = context.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(mapper.Map<PizzaFormViewModel>(pizza));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PizzaFormViewModel vm)
        {
            var pizza = context.Pizzas.Find(vm.Id);
            if (pizza == null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(pizza.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, pizza);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    
    }
}
