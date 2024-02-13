using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eniyisinerede.webui.Controllers;

public class CityController : Controller
{
    private readonly ICityService _cityService;
    private readonly ICountryService _countryService;

    public CityController(ICityService cityService, ICountryService countryService)
    {
        _cityService = cityService;
        _countryService = countryService;
    }

    public async Task<IActionResult> Index()
    {
        var cities = await _cityService.GetAllAsync();

        return View(cities);
    }
    public async Task<IActionResult> Details(int id)
    {
        var city= await _cityService.GetByIdAsync(id);
        return View();
    }
    //CREATE
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCityViewModel createCityViewModel)
    {
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name");

        var city = await _cityService.CreateAsync(createCityViewModel);

        return View();
    }
    //UPDATE
    public async Task<IActionResult> Update(int id)
    {
        var city= await _cityService.GetByIdAsync(id);
        var updateCityViewModel = new UpdateCityViewModel
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        };
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name", city.CountryId);
        return View(updateCityViewModel);
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCityViewModel updateCityViewModel)
    {
        var city = await _cityService.UpdateAsync(updateCityViewModel);
        if (city != null)
            return RedirectToAction(nameof(Details), city.Id);

        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name", updateCityViewModel.CountryId);
        return View();
    }
}
