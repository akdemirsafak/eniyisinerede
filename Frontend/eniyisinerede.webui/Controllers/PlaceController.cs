using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Places;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class PlaceController : Controller
{
    private readonly IPlaceService _placeService;
    private readonly IMapper _mapper;
    public PlaceController(IPlaceService placeService, IMapper mapper)
    {
        _placeService = placeService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var places = await _placeService.GetAllAsync();
        return View(places);
    }
    public async Task<IActionResult> Details(string id)
    {
        var place = await _placeService.GetByIdAsync(id);
        if (place is null)
            return Redirect(nameof(Index));

        return View(place);
    }
    //CREATE
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreatePlaceViewModel createPlaceViewModel)
    {
        var place = await _placeService.CreateAsync(createPlaceViewModel);
        if (place is null)
            return View(createPlaceViewModel);

        return RedirectToAction(nameof(Details), new { id = place.Id });
    }
    //UPDATE
    public async Task<IActionResult> Update(string id)
    {
        var place = await _placeService.GetByIdAsync(id);
        if (place is null)
            return Redirect(nameof(Index));

        var updatePlaceViewModel = _mapper.Map<UpdatePlaceViewModel>(place);
        return View(updatePlaceViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdatePlaceViewModel updatePlaceViewModel)
    {
        var place = await _placeService.UpdateAsync(updatePlaceViewModel);
        if (place is null)
            return View(updatePlaceViewModel);

        return RedirectToAction(nameof(Details), new { id = place.Id });
    }
}
