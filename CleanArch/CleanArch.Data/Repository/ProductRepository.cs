using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

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

        public async Task<IEnumerable<Product>> Get()
        {
            return  _ctx.Product;
        }
    }
}
