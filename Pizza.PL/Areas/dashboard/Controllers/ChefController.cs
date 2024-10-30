using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.chef;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class ChefController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ChefController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var chef = context.Chefs.ToList();
            var chf = mapper.Map<IEnumerable<ChefIndex>>(chef);
            return View("Index", chf);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ChefFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var chef = mapper.Map<Chef>(vm);
            context.Add(chef);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var chef = context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ChefDetails>(chef));
        }
        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var chef = context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }
            FilesSetting.DeleteFile(chef.ImgName, "Img");
            context.Chefs.Remove(chef);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var chef = context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ChefFormViewModel>(chef));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ChefFormViewModel vm)
        {
            var chef = context.Chefs.Find(vm.Id);
            if (chef == null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(chef.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, chef);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
