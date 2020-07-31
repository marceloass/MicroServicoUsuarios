using JuntosSeguros.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuntosSeguros.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MARCELO-PC\SQLEXPRESS; Initial Catalog=JuntosSeguro; 
            Persist Security Info=False;User ID=sa;Password=sudosu;");
        }
    }
}
