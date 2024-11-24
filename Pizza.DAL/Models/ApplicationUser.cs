using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
    }
}
