using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace SharedLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ApiResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,

            };
        }
    }
}
