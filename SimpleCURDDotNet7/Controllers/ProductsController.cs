using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.Interfaces;

namespace SimpleCURDDotNet7.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(Product model)
        {
            return Ok(await _productService.SaveProduct(model));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, Product model)
        {
            return Ok(await _productService.UpdateProduct(id, model));
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }
    }
}
