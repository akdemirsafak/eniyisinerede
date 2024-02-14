using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Countries;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class CountryController : Controller
{
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;

    public CountryController(ICountryService countryService, IMapper mapper)
    {
        _countryService = countryService;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var countries = await _countryService.GetAllAsync();
        return View(countries);
    }

    public async Task<IActionResult> Details(int id)
    {
        var country = await _countryService.GetByIdAsync(id);
        if (country is null)
            return RedirectToAction(nameof(Index));

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
        if (country is not null)
            return RedirectToAction(nameof(Details), new { id = country.Id });

        return View(createCountryViewModel);
    }

    public async Task<IActionResult> Update(int id)
    {
        var country = await _countryService.GetByIdAsync(id);
        if (country is null)
            return RedirectToAction(nameof(Index));
        return View(_mapper.Map<UpdateCountryViewModel>(country));
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCountryViewModel updateCountryViewModel)
    {
        var country = await _countryService.UpdateAsync(updateCountryViewModel);
        if (country is not null)
            return RedirectToAction(nameof(Details), new { id = country.Id });
        return View(updateCountryViewModel);
    }
}