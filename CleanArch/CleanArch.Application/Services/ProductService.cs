using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMediatorHandler mediatorHandler;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mediatorHandler = mediatorHandler;
            this.mapper = mapper;
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            var createProductCommand = mapper.Map<CreateProductCommand>(productViewModel);

            mediatorHandler.SendCommand(createProductCommand);
        }

        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            var result = await productRepository.Get();
            return result.ProjectTo<ProductViewModel>(mapper.ConfigurationProvider);
        }

        public async Task DeleteProductById(int Id)
        {
            await productRepository.DeleteProductById(Id);
        }

        public async Task<ProductViewModel> GetProductById(int Id)
        {
            var product = await productRepository.GetProductById(Id);
            var ProductViewModel = mapper.Map<ProductViewModel>(product);

            return ProductViewModel;
        }

        public async Task<ProductViewModel> EditProduct(ProductViewModel productViewModel)
        {
            var editProduct = mapper.Map<Product>(productViewModel);
            await productRepository.EditProduct(editProduct);
            var ProductViewModel = mapper.Map<ProductViewModel>(editProduct);
            return ProductViewModel;
        }
    }
}
