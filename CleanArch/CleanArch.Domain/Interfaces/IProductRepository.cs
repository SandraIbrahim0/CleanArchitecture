using CleanArch.Domain.Models;


namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
    }
}
