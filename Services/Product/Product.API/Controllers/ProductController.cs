using Microsoft.AspNetCore.Mvc;
using Product.API.RequestModels;
using Product.API.Services;
using SharedLibrary.Controllers;

namespace Product.API.Controllers;


public class ProductController : CustomBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest productDto)
    {
        var product = await _productService.CreateAsync(productDto);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest productDto)
    {
        var product = await _productService.UpdateAsync(id,productDto);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = await _productService.DeleteAsync(id);
        return Ok(product);
    }
}
