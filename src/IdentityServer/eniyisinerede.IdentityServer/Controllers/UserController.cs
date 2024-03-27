using eniyisinerede.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using SharedLibrary.Controllers;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace eniyisinerede.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)] //Claim bazlı yetkilendirme işlemi gerçekleşiyor.
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim=User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);//Bu id token'dan geliyor parametre olarak almamıza gerek yok.
            if (userIdClaim == null)
            {
                return BadRequest();
            }
            var user= await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
            {
                return BadRequest();
            }
            var userDto= new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
            return Ok(userDto);
        }
    }
}
