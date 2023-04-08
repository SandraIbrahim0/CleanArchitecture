using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> Get();
        void Add(Product product);
        Task<Product> GetProductById(int Id);
        Task DeleteProductById(int Id);
        Task EditProduct(Product product);
    }
}
