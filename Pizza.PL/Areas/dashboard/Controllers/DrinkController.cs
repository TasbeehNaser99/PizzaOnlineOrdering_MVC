using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.drink;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class DrinkController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DrinkController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var drink = context.Drinks.ToList();
            var drk = mapper.Map<IEnumerable<DrinkIndex>>(drink);
            return View("Index", drk);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(DrinkFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var drink = mapper.Map<Drink>(vm);
            context.Add(drink);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var drink = context.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(mapper.Map<DrinkDetails>(drink));
        }
        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var drink = context.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }
            FilesSetting.DeleteFile(drink.ImgName, "Img");
            context.Drinks.Remove(drink);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var drink = context.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(mapper.Map<DrinkFormViewModel>(drink));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DrinkFormViewModel vm)
        {
            var drink = context.Drinks.Find(vm.Id);
            if (drink == null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(drink.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, drink);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
