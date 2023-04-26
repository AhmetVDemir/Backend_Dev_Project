using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IUserService _userService;
        IFormService _formService;
        public ClientController(IUserService userService, IFormService formService)
        {
            _userService = userService;
            _formService = formService;
        }

        [HttpGet("GET")]
        public IActionResult Get()
        {
            var result = _formService.getFormsbyUser(1);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("Hata oluştu.");
        }


        [HttpPost("POST")]
        public IActionResult Post(Form form)
        {
            var result = _formService.saveFormtoDb(form);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("Hata oluştu.");
        }

    }
}
