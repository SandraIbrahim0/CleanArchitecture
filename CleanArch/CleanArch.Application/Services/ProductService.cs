using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    }
}
