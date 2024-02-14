using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var products =await _productService.GetAllAsync();
        return View(products);
    }
    public async Task<IActionResult> List()
    {
        var products =await _productService.GetAllAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await _productService.GetAsync(id);
        if (product is not null)
            return View(product);

        return RedirectToAction(nameof(Index));
    }

    //Create

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
    {
        var product = await _productService.CreateAsync(createProductViewModel);
        if (product is not null)
            return RedirectToAction(nameof(Details), new { id = product.Id });

        return View(createProductViewModel);

    }

    //Update

    public async Task<IActionResult> Update(Guid id)
    {
        var data = await _productService.GetAsync(id);
        var updateProductViewModel = _mapper.Map<UpdateProductViewModel>(data);
        return View(updateProductViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductViewModel updateProductViewModel)
    {
        var product = await _productService.UpdateAsync(updateProductViewModel);
        if (product is not null)
            return RedirectToAction(nameof(Details), new { id = product.Id });
        return View(updateProductViewModel);
    }
}
