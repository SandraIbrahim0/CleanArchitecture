using CleanArch.Api.Controllers;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using Application.Test.MockData;

namespace Application.Test
{
    public class ProductServiceTests
    {

        [Fact]
        public async Task Should_Return_Product_ListAsync()
        {
            //Arrange
            var productService = new Mock<IProductService>();
            var loggerService = new Mock<ILogger<ProductController>>();
            productService.Setup(x => x.Get()).ReturnsAsync(ProductMockData.GetProducts());
            var productController = new ProductController(loggerService.Object, productService.Object);

            // Act
            var result = (OkObjectResult)await productController.GetProducts();
            var productsResult = result.Value as List<ProductViewModel>;

            //Assert
            Assert.Equal(2, productsResult?.Count);
        }

        [Fact]
        public async Task Should_Save_Product()
        {
            //Arrange
            var productService = new Mock<IProductService>();
            var loggerService = new Mock<ILogger<ProductController>>();
            var productController = new ProductController(loggerService.Object, productService.Object);

            var productViewModel = new ProductViewModel { Description = "Product_Test_Description", Id = 1, Name = "Product_Test", Price = 200.5, Quantity = 2 };

            productService.Setup(x => x.CreateProduct(productViewModel));

            // Act
            var result = (OkObjectResult)productController.CreateProduct(productViewModel);

            //Assert
            Assert.Equal<int>(200, result.StatusCode.Value);
        }
    }
}
