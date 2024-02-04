using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }
 
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
  
        [HttpPut("{id}")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
