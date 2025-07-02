using FastCacheApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastCacheApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }

    [HttpPost("refresh-cache")]
    public async Task<IActionResult> RefreshCache()
    {
        await _productService.RefreshCache();
        return NoContent();
    }
}