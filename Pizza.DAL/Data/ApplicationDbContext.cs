using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza.DAL.Models;

namespace Pizza.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<PizzaType> Pizzas { get; set; }
        public DbSet<Pasta> Pastas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Burger> Burgers { get; set;}

    }
}
