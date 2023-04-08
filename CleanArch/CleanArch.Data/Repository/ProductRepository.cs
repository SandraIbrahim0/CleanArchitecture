using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDBContext _ctx;
        public ProductRepository(ProductDBContext productDBContext)
        {
            _ctx = productDBContext;
        }

        public void Add(Product product)
        {
            _ctx.Add(product);
            _ctx.SaveChanges();
        }

        public async Task<IQueryable<Product>> Get()
        {
            return _ctx.Product;
        }

        public async Task<Product> GetProductById(int Id)
        {
            IQueryable<Product> products = _ctx.Product;
            return await products.FirstAsync(x => x.Id == Id);
        }

        public async Task DeleteProductById(int Id)
        {
            //Bulk Deletion
            await _ctx.Product.Where(x => x.Id == Id).ExecuteDeleteAsync();

        }

        public async Task EditProduct(Product product)
        {
            await _ctx.Product.Where(p => p.Id == product.Id)
                      .ExecuteUpdateAsync(s => s
                      .SetProperty(b => b.Name, product.Name)
                      .SetProperty(b => b.Description, product.Description)
                      .SetProperty(b => b.Quantity, product.Quantity)
                      .SetProperty(b => b.Price, product.Price));
        }
    }
}
