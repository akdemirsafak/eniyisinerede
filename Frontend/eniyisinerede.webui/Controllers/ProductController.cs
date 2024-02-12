using eniyisinerede.webui.Services.Interfaces;
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

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        return View();
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Update(Guid id)
    {
        return View();
    }
}
