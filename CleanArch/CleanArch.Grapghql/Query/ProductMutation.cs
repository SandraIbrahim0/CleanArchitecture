using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;

namespace CleanArch.Grapghql.Query
{
    public class ProductMutation
    {
        public ProductViewModel CreateProduct([Service] IProductService productService, ProductViewModel productViewModel)
        {
            productService.CreateProduct(productViewModel);
            return productViewModel;
        }

        public async Task<ProductViewModel> UpdateProduct([Service] IProductService productService, ProductViewModel productViewModel)
        {
            var updateProduct = await productService.EditProduct(productViewModel);
            return updateProduct;
        }

        public async Task<List<ProductViewModel>> DeleteProduct([Service] IProductService productService, int productId)
        {
            await productService.DeleteProductById(productId);
            var products = await productService.Get();
            return products.ToList();
        }

    }
}
