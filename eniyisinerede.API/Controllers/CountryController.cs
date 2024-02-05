using eniyisinerede.API.RequestModels.Country;
using eniyisinerede.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;


    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        return Ok(await _countryService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        //
        return Ok(await _countryService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request)
    {


        return Ok(await _countryService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryRequest request)
    {
        return Ok(await _countryService.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _countryService.DeleteAsync(id);
        return Ok();
    }
}
