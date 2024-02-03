using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PalaceController : ControllerBase
{
    // GET: api/Palace
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET: api/Palace/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/Palace
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Palace/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
