using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.DAL.Data;
using Pizza.PL.Areas.dashboard.ViewModels.burger;
using Pizza.PL.Areas.dashboard.ViewModels.chef;
using Pizza.PL.Areas.dashboard.ViewModels.drink;
using Pizza.PL.Areas.dashboard.ViewModels.pasta;
using Pizza.PL.Areas.dashboard.ViewModels.pizza;
using Pizza.PL.Areas.dashboard.ViewModels.service;
using Pizza.PL.Models;
using System.Diagnostics;
using System.Dynamic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizza.PL.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var burger = context.Burgers.Take(3).ToList();
            var pizza3 = context.Pizzas.Take(3).ToList();
            var drink = context.Drinks.Take(3).ToList();
            var pasta = context.Pastas.Take(3).ToList();
            var pizza8 = context.Pizzas.Take(8).ToList();
            var service = context.Services.Take(3).ToList();
            var bur = mapper.Map<IEnumerable<BurgerDetails>>(burger);
            var piz3 = mapper.Map<IEnumerable<PizzaDetails>>(pizza3);
            var piz8 = mapper.Map<IEnumerable<PizzaDetails>>(pizza8);
            var pas = mapper.Map<IEnumerable<PastaDetails>>(pasta);
            var dnk = mapper.Map<IEnumerable<DrinkDetails>>(drink);
            var ser = mapper.Map<IEnumerable<ServiceDetails>>(service);
            dynamic data = new ExpandoObject();
            data.burger = bur;
            data.pizza3 = piz3;
            data.drink = dnk;
            data.pasta = pas;
            data.pizza8 = piz8;
            data.service = ser;
            return View("Index", data);
        }
        public IActionResult Menu()
        {
            var pizza8 = context.Pizzas.Take(8).ToList();
            var burger = context.Burgers.Take(3).ToList();
            var drink = context.Drinks.Take(3).ToList();
            var pasta = context.Pastas.Take(3).ToList();
            var piz8 = mapper.Map<IEnumerable<PizzaDetails>>(pizza8);
            var pas = mapper.Map<IEnumerable<PastaDetails>>(pasta);
            var dnk = mapper.Map<IEnumerable<DrinkDetails>>(drink);
            var bur = mapper.Map<IEnumerable<BurgerDetails>>(burger);
            dynamic data = new ExpandoObject();
            data.burger = bur;
            data.drink = dnk;
            data.pasta = pas;
            data.pizza8 = piz8;

            return View("Menu", data);
        }
        public IActionResult Service()
        {
            var pizza8 = context.Pizzas.Take(8).ToList();
            var service = context.Services.Take(3).ToList();
            var ser = mapper.Map<IEnumerable<ServiceDetails>>(service);
            var piz8 = mapper.Map<IEnumerable<PizzaDetails>>(pizza8);
            dynamic data = new ExpandoObject();
            data.pizza8 = piz8;
            data.service = ser;
            return View("Services", data);

        }
        public IActionResult About()
        {
            var chef = context.Chefs.ToList();
            var chf = mapper.Map<IEnumerable<ChefDetails>>(chef);
            dynamic data = new ExpandoObject();
            data.chef = chf;
            return View("About", data);

        }
        public IActionResult Blog()
        {
            return View("Blog");
        }
        public IActionResult Concat()
        {
            return View("Concat");
        }
        public IActionResult ReadBlog()
        {
            return View("ReadBlog");
        }

    }
}
