using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> Get();
        void Add(Product product);
    }
}
