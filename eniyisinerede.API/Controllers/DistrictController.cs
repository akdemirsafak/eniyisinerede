using eniyisinerede.API.RequestModels.District;
using eniyisinerede.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _districtService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _districtService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDistrictRequest request)
    {
        return Ok(await _districtService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDistrictRequest request)
    {
        return Ok(await _districtService.UpdateAsync(id,request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _districtService.DeleteAsync(id);
        return Ok();
    }
}
