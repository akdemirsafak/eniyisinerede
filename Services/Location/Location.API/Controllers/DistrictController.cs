using Location.API.RequestModels.District;
using Location.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;


public class DistrictController : CustomBaseController
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _districtService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _districtService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDistrictRequest request)
    {
        return CreateActionResult(await _districtService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDistrictRequest request)
    {
        return CreateActionResult(await _districtService.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _districtService.DeleteAsync(id));
    }
}
