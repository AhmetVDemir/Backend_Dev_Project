using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MVCApp.Controllers
{
    public class AuthController : Controller
    {
        IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string Email, string Password)
        {

            User tempUser = _userService.GetUser(Email);
            if (tempUser != null && Password == tempUser.Password)
            {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, tempUser.Name),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Forms");

            }
            else
            {
                return RedirectToAction("Index", "Auth");
            }

            
                
        }
    }
}
