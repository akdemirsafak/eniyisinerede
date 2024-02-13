using AutoMapper;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eniyisinerede.webui.Controllers;

public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;
    private readonly IPlaceService _placeService;
    private readonly IMapper _mapper;

    public ReservationController(IReservationService reservationService, IPlaceService placeService, IMapper mapper)
    {
        _reservationService = reservationService;
        _mapper = mapper;
        _placeService = placeService;
    }

    public async Task<IActionResult> Index()
    {
        var datas = await _reservationService.GetAllAsync();
        return View(datas);
    }
    //Create
    public async Task<IActionResult> Create()
    {
        //ViewBag.Places = await _placeService.GetAllAsync();
        ViewBag.Places = new SelectList(await _placeService.GetAllAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationViewModel createReservationViewModel)
    {
        var result = await _reservationService.CreateAsync(createReservationViewModel);
        if (result != null)
            return RedirectToAction(nameof(Index));

        ViewBag.Places = await _placeService.GetAllAsync();
        return View();//createReservationViewModel
    }
    //Update
    public async Task<IActionResult> Update(string id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        ViewBag.Places = new SelectList(await _placeService.GetAllAsync(), "Id", "Name", reservation.PlaceId);
        if (reservation is null)
            return RedirectToAction(nameof(Index));


        var model=_mapper.Map<UpdateReservationViewModel>(reservation);
        return View(model);

    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateReservationViewModel updateReservationViewModel)
    {
        var result =await _reservationService.UpdateAsync(updateReservationViewModel);
        if (result)
            return RedirectToAction(nameof(Index));

        ViewBag.Places = new SelectList(await _placeService.GetAllAsync(), "Id", "Name", updateReservationViewModel.PlaceId);
        return View();
    }
    public async Task<IActionResult> Passive(string id)
    {
        var result = await _reservationService.CancellReservationAsync(id);
        if (result)
            return RedirectToAction(nameof(Index));

        return View();
    }
    public async Task<IActionResult> Details(string id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        var place=await _placeService.GetByIdAsync(reservation.PlaceId);
        ViewBag.Place = place;

        return View(reservation);
    }
}
