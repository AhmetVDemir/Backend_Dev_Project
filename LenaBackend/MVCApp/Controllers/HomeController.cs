using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("getall")]
        public IActionResult Get() {
            var result = _userService.GetUser("mumaru171@gmaiil.com");
            if (result == null) {
                return BadRequest("Bulunamadı");
            }
            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

    }
}