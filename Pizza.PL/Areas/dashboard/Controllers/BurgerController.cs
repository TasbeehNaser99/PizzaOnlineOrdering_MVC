using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.burger;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    public class BurgerController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BurgerController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var burger = context.Burgers.ToList();
            var bur = mapper.Map<IEnumerable<BurgerIndex>>(burger);
            return View("Index", bur);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(BurgerFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var burger = mapper.Map<Burger>(vm);
            context.Add(burger);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var burger = context.Burgers.Find(id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(mapper.Map<BurgerDetails>(burger));
        }
        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var burger = context.Burgers.Find(id);
            if (burger == null)
            {
                return NotFound();
            }
            FilesSetting.DeleteFile(burger.ImgName, "Img");
            context.Burgers.Remove(burger);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var burger = context.Burgers.Find(id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(mapper.Map<BurgerFormViewModel>(burger));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BurgerFormViewModel vm)
        {
            var burger = context.Burgers.Find(vm.Id);
            if (burger == null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(burger.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, burger);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
