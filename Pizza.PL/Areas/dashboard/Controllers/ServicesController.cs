using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.service;
using Pizza.PL.Helpers;

namespace Pizza.PL.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var services=context.Services.ToList();
            var serv = mapper.Map<IEnumerable<ServiceIndex>>(services);
            return View(serv);
        }

        [HttpGet]  
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public IActionResult Create(ServiceFormViewModel vm) { 
            if(!ModelState.IsValid) {
                return View(vm);
            }
            vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            var service =mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var services = context.Services.Find(id);
            if(services == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServiceDetails>(services));
        }
          [HttpPost]
         
          public IActionResult DeleteConfirm(int id)
           {
               var services = context.Services.Find(id);
               if (services == null)
               {
                   return NotFound();
               }
              FilesSetting.DeleteFile(services.ImgName, "Img");
               context.Services.Remove(services);
               context.SaveChanges();
               return RedirectToAction(nameof(Index));
           }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
          var service = context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServiceFormViewModel>(service));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormViewModel vm)
        {
            var service = context.Services.Find(vm.Id);
            if (service == null)
            {
                return NotFound();
            }
            if(vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(service.ImgName, "img");
                vm.ImgName = FilesSetting.UploadFile(vm.Image, "img");
            }
            if (!ModelState.IsValid) { 
                return View(vm);
            }
            mapper.Map(vm, service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
