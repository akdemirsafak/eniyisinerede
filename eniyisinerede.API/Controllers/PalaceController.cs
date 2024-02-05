using eniyisinerede.API.RequestModels.Palace;
using eniyisinerede.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers;

[Route("[controller]")]
[ApiController]
public class PalaceController : ControllerBase
{
    private readonly IPalaceService _palaceService;

    public PalaceController(IPalaceService palaceService)
    {
        _palaceService = palaceService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _palaceService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _palaceService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePalaceRequest request)
    {
        return Ok(await _palaceService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePalaceRequest request)
    {
        return Ok(await _palaceService.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _palaceService.DeleteAsync(id);
        return Ok();
    }
}
