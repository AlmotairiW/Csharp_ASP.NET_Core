using FormSubmission.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormSubmission.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("")]

        public ViewResult FormPage()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult ProccessInfo(User newUser)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success", newUser);
            }
            return View("FormPage");
        }

        [HttpGet("success")]
        public ViewResult Success(User newUser)
        {
            return View("Success", newUser);
        }
    }
}