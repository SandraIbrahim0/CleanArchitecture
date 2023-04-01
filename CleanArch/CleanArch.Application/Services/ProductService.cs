using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMediatorHandler mediatorHandler;
        public ProductService(IProductRepository productRepository, IMediatorHandler mediatorHandler)
        {
            this.productRepository = productRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            var createProductCommand = new CreateProductCommand(productViewModel.Name, productViewModel.Description, productViewModel.Quantity, productViewModel.Price);
            mediatorHandler.SendCommand(createProductCommand);
        }

        public async Task<ProductViewModel> Get()
        {
            return new ProductViewModel { Products = await productRepository.Get() };
        }
    }
}
