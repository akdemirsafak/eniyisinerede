﻿using eniyisinerede.webui.Services.Interfaces;
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
    public async Task<IActionResult> List()
    {
        var datas =await _productService.GetAllAsync();
        return View(datas);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var data = await _productService.GetAsync(id);
        return View(data);
    }

    //Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
    {
        var result = await _productService.CreateAsync(createProductViewModel);
        return RedirectToAction(nameof(Index));
    }

    //Update

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        //("{id}")
        //var data = await _productService.GetAsync(id); 
        //var updateProductViewModel = new UpdateProductViewModel
        //{
        //    Id = data.Id,
        //    Name = data.Name,
        //    Description = data.Description,
        //    Price = data.Price,
        //    PictureUrl = data.PictureUrl
        //};updateProductViewModel
        return View();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateProductViewModel updateProductViewModel)
    {
        var result = await _productService.UpdateAsync(updateProductViewModel);
        return RedirectToAction(nameof(Index));
    }
}