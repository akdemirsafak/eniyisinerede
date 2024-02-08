using Location.API.RequestModels.Country;
using Location.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;

public class CountryController : CustomBaseController
{
    private readonly ICountryService _countryService;


    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        return CreateActionResult(await _countryService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _countryService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request)
    {
        return CreateActionResult(await _countryService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryRequest request)
    {
        return CreateActionResult(await _countryService.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _countryService.DeleteAsync(id));
    }
}
