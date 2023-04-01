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

        public ProductController(ILogger<ProductController> logger,IProductService productService)
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
        
    }
}