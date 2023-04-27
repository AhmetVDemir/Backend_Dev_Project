using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    [Authorize]
    public class FormsController : Controller
    {
        IFormService _formService;
        public FormsController(IFormService formService)
        {
            _formService = formService;
        }

        public IActionResult Index()
        {
            List<Form> formlar = _formService.getFormsbyUser(1);
            return View(formlar);
        }

        public IActionResult AddForm() {
            return View();
        }
    }
}
