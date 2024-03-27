using eniyisinerede.IdentityServer.Dtos;
using eniyisinerede.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;
using SharedLibrary.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace eniyisinerede.IdentityServer.Controllers
{
    public class AuthController : CustomBaseController
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var user = new ApplicationUser()
            {
                UserName=signupDto.UserName,
                Email=signupDto.Email
            };
            var result =await _userManager.CreateAsync(user,signupDto.Password);
            if (!result.Succeeded)
            {
                return CreateActionResult(ApiResponse<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }
            return CreateActionResult(ApiResponse<NoContent>.Success(201));
        }
    }
}
