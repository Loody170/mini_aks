using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProduct(Guid productId)
        {
            var product =  _productService.GetProduct(productId);
            return Ok(product);
        }

        [HttpGet("{productId}/items")]
        public IActionResult GetProductItems(Guid productId)
        {
            var productItems = _productService.GetProductItems(productId);
            return Ok(productItems);
        }
    }
}
