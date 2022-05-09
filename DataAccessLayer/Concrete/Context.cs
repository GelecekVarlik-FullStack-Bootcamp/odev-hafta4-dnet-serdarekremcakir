using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-T6A7864;" +
                "database=Odev4; integrated security=true;");
        }

        public DbSet<TaskWork> TaskWorks { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
