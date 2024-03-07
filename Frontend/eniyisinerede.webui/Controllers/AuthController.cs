using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace eniyisinerede.webui.Controllers;

public class AuthController : Controller
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInInputModel signInInputModel)
    {
        var response = await _identityService.SignInAsync(signInInputModel);
        if (response.Errors.Any())
        {
            response.Errors.ForEach(error => { ModelState.AddModelError(String.Empty, error); });
            return View();
        }


        return RedirectToAction(nameof(Index), "User");
    }
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //Cookie'leri siliyoruz.
        await _identityService.RevokeRefreshToken();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
