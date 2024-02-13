using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Countries;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class CountryController : Controller
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }
    public async Task<IActionResult> Index()
    {
        var countries = await _countryService.GetAllAsync();
        return View(countries);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var country = await _countryService.GetByIdAsync(id);
        return View(country);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryViewModel createCountryViewModel)
    {
        var country = await _countryService.CreateAsync(createCountryViewModel);
        if (country != null)
            return RedirectToAction(nameof(Index));

        return View(createCountryViewModel);
    }

    public async Task<IActionResult> Update(int id)
    {
        var country = await _countryService.GetByIdAsync(id);
        return View();
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCountryViewModel updateCountryViewModel)
    {
        var country = await _countryService.UpdateAsync(updateCountryViewModel);
        if (country != null)
            return RedirectToAction(nameof(Details), country);
        return View(updateCountryViewModel);
    }
}