using AutoMapper;
using Pizza.DAL.Models;
using Pizza.PL.Areas.dashboard.ViewModels.service;
using Pizza.PL.Areas.dashboard.ViewModels.pizza;
using Pizza.PL.Areas.dashboard.ViewModels.pasta;
using Pizza.PL.Areas.dashboard.ViewModels.drink;
using Pizza.PL.Areas.dashboard.ViewModels.burger;
using Pizza.PL.Areas.dashboard.ViewModels.chef;
namespace Pizza.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {
            CreateMap<ServiceFormViewModel, Service>().ReverseMap();
            CreateMap<Service,ServiceIndex > ();
            CreateMap<Service, ServiceDetails> ();
            CreateMap<PizzaFormViewModel, PizzaType>().ReverseMap();
            CreateMap<PizzaType, PizzaIndex>();
            CreateMap<PizzaType, PizzaDetails>();
            CreateMap<PastaFormViewModel, Pasta>().ReverseMap();
            CreateMap<Pasta, PastaIndex>();
            CreateMap<Pasta, PastaDetails>();
            CreateMap<DrinkFormViewModel, Drink>().ReverseMap();
            CreateMap<Drink, DrinkIndex>();
            CreateMap<Drink, DrinkDetails>();
            CreateMap<BurgerFormViewModel, Burger>().ReverseMap();
            CreateMap<Burger, BurgerIndex>();
            CreateMap<Burger, BurgerDetails>();
            CreateMap<ChefFormViewModel, Chef>().ReverseMap();
            CreateMap<Chef, ChefIndex>();
            CreateMap<Chef, ChefDetails>();
        }
    }
}
