using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;


namespace CleanArch.Grapghql.Query
{
    public class ProductQuery
    {
        private readonly IProductService productService;
        public ProductQuery(IProductService productService) { this.productService = productService; }

        public async Task<IQueryable<ProductViewModel>> GetProducts()
        {
            var result = await productService.Get();
            return result.AsQueryable();
        }

        public async Task<ProductViewModel> GetProductbyId( int id)
        {
            ProductViewModel product = await productService.GetProductById(id);
            return product;
        }
    }
}
