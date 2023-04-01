using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> Get(); 
        void CreateProduct(ProductViewModel productViewModel); 
    }
}
