﻿using Microsoft.AspNetCore.Mvc;
using Reservation.API.RequestModels;
using Reservation.API.Services;
using SharedLibrary.Controllers;

namespace Reservation.API.Controllers;

public class ReservationController : CustomBaseController
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _reservationService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return CreateActionResult(await _reservationService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
    {
        return CreateActionResult(await _reservationService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateReservationRequest request)
    {
        return CreateActionResult(await _reservationService.UpdateAsync(id, request));
    }
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> CancellReservation(string id)
    {
        return CreateActionResult(await _reservationService.CancellAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return CreateActionResult(await _reservationService.DeleteAsync(id));
    }
}
