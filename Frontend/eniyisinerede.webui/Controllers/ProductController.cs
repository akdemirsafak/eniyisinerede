using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IActionResult> Index()
    {
        var datas =await _productService.GetAllAsync();
        return View(datas);
    }
    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        var datas =await _productService.GetAllAsync();
        return View(datas);
    }

    [HttpGet("ProductDetails/{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        var data = await _productService.GetAsync(id);
        if (data == null)
            return RedirectToAction(nameof(Index));
        return View(data);
    }

    //Create

    [HttpGet("CreateProduct")]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost("CreateProduct")]
    public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
    {
        var result = await _productService.CreateAsync(createProductViewModel);
        return RedirectToAction(nameof(Index));
    }

    //Update

    [HttpGet("UpdateProduct/{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        var data = await _productService.GetAsync(id);
        var updateProductViewModel = new UpdateProductViewModel
        {
            Id = data.Id,
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            PictureUrl = data.PictureUrl
        };
        return View(updateProductViewModel);
    }

    [HttpPut("UpdateProduct")]

    public async Task<IActionResult> Update(UpdateProductViewModel updateProductViewModel)
    {
        var result = await _productService.UpdateAsync(updateProductViewModel);
        return RedirectToAction(nameof(Index));
    }
}
