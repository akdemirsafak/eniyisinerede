using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eniyisinerede.webui.Controllers;

public class CityController : Controller
{
    private readonly ICityService _cityService;
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;
    public CityController(ICityService cityService, ICountryService countryService, IMapper mapper)
    {
        _cityService = cityService;
        _countryService = countryService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var cities = await _cityService.GetAllAsync();

        return View(cities);
    }
    public async Task<IActionResult> Details(int id)
    {
        var city= await _cityService.GetByIdAsync(id);
        if (city is null)
            return RedirectToAction(nameof(Index));

        ViewBag.Country = await _countryService.GetByIdAsync(city.CountryId);
        return View(city);
    }
    //CREATE
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCityViewModel createCityViewModel)
    {
        var city = await _cityService.CreateAsync(createCityViewModel);
        if (city is not null)
            return RedirectToAction(nameof(Details), new { id = city.Id });

        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name");

        return View();
    }
    //UPDATE
    public async Task<IActionResult> Update(int id)
    {
        var city= await _cityService.GetByIdAsync(id);

        var updateCityViewModel = _mapper.Map<UpdateCityViewModel>(city);
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name", city.CountryId);
        return View(updateCityViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCityViewModel updateCityViewModel)
    {
        var city = await _cityService.UpdateAsync(updateCityViewModel);
        if (city is not null)
            return RedirectToAction(nameof(Details), new { id = city.Id });

        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name", updateCityViewModel.CountryId);
        return View();
    }
}
