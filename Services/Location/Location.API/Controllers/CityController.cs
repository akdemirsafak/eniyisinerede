using Location.API.RequestModels.City;
using Location.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;

public class CityController : CustomBaseController
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _cityService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _cityService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
    {
        return CreateActionResult(await _cityService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityRequest request)
    {
        return CreateActionResult(await _cityService.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _cityService.DeleteAsync(id));
    }
}
