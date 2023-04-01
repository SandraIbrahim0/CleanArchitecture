using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Context
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
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
                new Product {  Id = 1 , Name = "Laptop", Price = 20.02, Quantity = 10 ,Description =" A laptop can be easily transported and used in temporary spaces such as on airplanes, in libraries, temporary offices and at meetings"},
                new Product {  Id= 2 , Name = "Phone", Price = 20.99, Quantity = 20,Description = " a portable telephone that can make and receive calls over a radio frequency link while the user is moving within a telephone service area,"},

            };
        }
    }
}
