using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Entites.Models;

namespace MyShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = "Server=.;Database=MyShop;User Id=sa;Password=End@game2020;TrustServerCertificate=true;";
        //    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyShop.DataAccess"));
        //}
        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

    }
}
