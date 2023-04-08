using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductViewModel productViewModel)
        {
            productService.CreateProduct(productViewModel);
            return Ok(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await productService.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetProductById([FromQuery] int Id)
        {
            var result = await productService.GetProductById(Id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditProductById([FromBody] ProductViewModel productViewModel)
        {
            var result = await productService.EditProduct(productViewModel);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int Id)
        {
            productService.DeleteProductById(Id);
            return Ok();
        }

    }
}