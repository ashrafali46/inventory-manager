using System.Linq;
using Api.Serialization;
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

            var productViewModels = products.Select(ProductMapper.SerializeProductModel);

            return Ok(productViewModels);
        }

        [HttpGet("/api/product/{id}")]
        public ActionResult GetProduct(int id)
        {
            _logger.LogInformation($"Getting a single product with id of: {id}");

            var product = _productService.GetProductById(id);

            return Ok(product);
        }

        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation($"Archiving product ID#: {id}");

            var archiveResult = _productService.ArchiveProduct(id);

            return Ok(archiveResult);
        }
    }
}