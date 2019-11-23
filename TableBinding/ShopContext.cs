using Microsoft.EntityFrameworkCore;

namespace TableBinding
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NVDGPN3;Database=ShopDatabase;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Bread",
                    Price = 13,
                    Count = 5,
                },
                new Product
                {
                    Name = "Soap",
                    Price = 10,
                    Count = 10,
                },
                new Product
                {
                    Name = "Butter",
                    Price = 200,
                    Count = 5,
                }, new Product
                {
                    Name = "Milk",
                    Price = 130,
                    Count = 7,
                }
                );
        }
    }
}
