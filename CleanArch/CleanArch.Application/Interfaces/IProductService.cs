using CleanArch.Application.ViewModels;
using System.Collections.Generic;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> Get(); 
        void CreateProduct(ProductViewModel productViewModel);
        Task<ProductViewModel> GetProductById(int Id);
        Task DeleteProductById(int Id);
        Task<ProductViewModel> EditProduct(ProductViewModel productViewModel);
    }
}
