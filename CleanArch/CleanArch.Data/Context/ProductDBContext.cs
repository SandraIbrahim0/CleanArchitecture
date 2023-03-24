using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Context
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {  Id = 1 , Name = "Laptop", Price = 20.02, Quantity = 10},
                new Product {  Id= 2 , Name = "Phone", Price = 20.99, Quantity = 20},

            };
        }
    }
}
