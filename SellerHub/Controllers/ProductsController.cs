using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellerHub.DTOs;
using SellerHub.Services;
using System.Security.Claims;

namespace SellerHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET /api/products?search=lego
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string search)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var products = await _productService.SearchSellerProductsAsync(sellerId, search);
            return Ok(products);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterProducts(
            [FromQuery] string? category,
            [FromQuery] string? stockStatus,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var products = await _productService.FilterSellerProductsAsync(sellerId, category, stockStatus, minPrice, maxPrice);
            return Ok(products);
        }



        [HttpPut("bulk-edit")]
        public async Task<IActionResult> BulkEdit([FromBody] BulkEditProductDto dto)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var updatedProducts = await _productService.BulkEditProductsAsync(dto, sellerId);
            return Ok(updatedProducts);
        }



    }
}
