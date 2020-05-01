using System.Linq;
using Api.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Product;

namespace Api.Controllers
{
    [Route("api/[controller]")]
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

            var products = _productService.GetAllProducts();

            var productViewModels = products.Select(ProductMapper.SerializedProductModel);

            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            _logger.LogInformation($"Getting a single product with id of: {id}");

            var product = _productService.GetProductById(id);

            return Ok(product);
        }
    }
}