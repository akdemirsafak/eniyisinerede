using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    // GET: api/Country
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET: api/Country/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/Country
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Country/5
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
