using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Product;

namespace Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            _logger.LogInformation("Getting all products");

            _productService.GetAllProducts();
            return Ok();
        }

        [HttpGet("id")]
        public ActionResult GetProduct()
        {
            _logger.LogInformation("Getting a single product with id of: ${id}");

            return Ok();

        }
    }
}