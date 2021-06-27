
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginRegistration.Models;

namespace SimpleLoginRegistration.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Reg(RegUser newUser)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Success");
            
            return View("Index");
        }

        [HttpPost("logIn")]
        public IActionResult LogIn(LogUser loggedUser)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Success");
            
            return View("Index");
        }

        [HttpGet("success")]
        public string Success()
        {
            return "You have successfully submitted!";
        }

    }
}
