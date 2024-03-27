using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Districts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eniyisinerede.webui.Controllers;

public class DistrictController : Controller
{
    private readonly IDistrictService _districtService;
    private readonly ICityService _cityService;
    private readonly IMapper _mapper;
    public DistrictController(IDistrictService districtService, ICityService cityService, IMapper mapper)
    {
        _districtService = districtService;
        _cityService = cityService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var districts = await _districtService.GetAllAsync();
        return View(districts);
    }
    public async Task<IActionResult> Details(int id)
    {
        var district = await _districtService.GetByIdAsync(id);
        if (district is null)
            return RedirectToAction(nameof(Index));

        ViewBag.City = await _cityService.GetByIdAsync(district.CityId);

        return View(district);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateDistrictViewModel createDistrictViewModel)
    {
        var district = await _districtService.CreateAsync(createDistrictViewModel);
        if (district is not null)
            return RedirectToAction(nameof(Details), new { id = district.Id });

        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name");
        return View(createDistrictViewModel);
    }
    public async Task<IActionResult> Update(int id)
    {
        var district = await _districtService.GetByIdAsync(id);

        var updateDistrictViewModel = _mapper.Map<UpdateDistrictViewModel>(district);
        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name", updateDistrictViewModel.CityId);
        return View(updateDistrictViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateDistrictViewModel updateDistrictViewModel)
    {
        var district = await _districtService.UpdateAsync(updateDistrictViewModel);

        if (district is not null)
            return RedirectToAction(nameof(Details), new { id = district.Id });

        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name", updateDistrictViewModel.CityId);
        return View(updateDistrictViewModel);
    }
}
