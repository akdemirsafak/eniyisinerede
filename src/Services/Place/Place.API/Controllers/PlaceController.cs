using Microsoft.AspNetCore.Mvc;
using Place.API.Models;
using Place.API.Services;
using SharedLibrary.Controllers;

namespace Place.API.Controllers;


public class PlaceController : CustomBaseController
{
    private readonly IPlaceService _placeService;

    public PlaceController(IPlaceService placeService)
    {
        _placeService = placeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _placeService.GetAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return CreateActionResult(await _placeService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlaceRequest createRequest)
    {
        return CreateActionResult(await _placeService.CreateAsync(createRequest));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdatePlaceRequest updateRequest)
    {
        return CreateActionResult(await _placeService.UpdateAsync(id,updateRequest));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return CreateActionResult(await _placeService.RemoveAsync(id));
    }
}
