using eniyisinerede.API.RequestModels.City;
using eniyisinerede.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _cityService.GetByIdAsync(id));
        }
 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
        {
            return Ok(await _cityService.CreateAsync(request));
        }
  
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCityRequest request)
        {
            return Ok(await _cityService.UpdateAsync(id,request));
        }
  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityService.DeleteAsync(id);
            return Ok();
        }
    }
}
