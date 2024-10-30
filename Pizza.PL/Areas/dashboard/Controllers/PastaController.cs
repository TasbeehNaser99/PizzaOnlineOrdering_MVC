using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.pasta;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class PastaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PastaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var pasta = context.Pastas.ToList();
            var pas = mapper.Map<IEnumerable<PastaIndex>>(pasta);
            return View("Index", pas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PastaFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var pasta = mapper.Map<Pasta>(vm);
            context.Add(pasta);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var pasta = context.Pastas.Find(id);
            if (pasta == null)
            {
                return NotFound();
            }
            return View(mapper.Map<PastaDetails>(pasta));
        }
        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var pasta = context.Pastas.Find(id);
            if (pasta == null)
            {
                return NotFound();
            }
            FilesSetting.DeleteFile(pasta.ImgName, "Img");
            context.Pastas.Remove(pasta);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pasta = context.Pastas.Find(id);
            if (pasta == null)
            {
                return NotFound();
            }
            return View(mapper.Map<PastaFormViewModel>(pasta));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PastaFormViewModel vm)
        {
            var pasta = context.Pastas.Find(vm.Id);
            if (pasta == null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(pasta.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm, pasta);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
