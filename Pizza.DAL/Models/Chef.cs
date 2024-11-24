using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Models
{
    public class Chef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ImgName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
