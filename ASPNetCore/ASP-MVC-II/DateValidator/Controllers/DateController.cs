using DateValidator.Models;
using Microsoft.AspNetCore.Mvc;

namespace DateValidator.Controllers
{
    public class DateController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Proccess( Date newDate)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Success", newDate);
            return View("Index", newDate);
        }

        [HttpGet("success")]
        public ViewResult Success(Date newDate)
        {
            return View("Success", newDate);
        }
    }
}