using EFCore.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi>? Herois { get; set; }
        public DbSet<Batalha>? Batalhas { get; set; }
        public DbSet<Arma>? Armas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Password=meuteste;Persist Security Info=True;User ID=diamante;Initial Catalog=herois;Data Source=GUILHERME\\SQLEXPRESS");
        }

    }
}
