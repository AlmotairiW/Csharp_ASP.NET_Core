using DojoSurvey.Models;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View("Form");
        }

        [HttpPost("result")]
        public ViewResult FormSubmit(Survey survey)
        {
            if(ModelState.IsValid)
            {
                return View("Display", survey);
            }
            return View("Form", survey);

        }
    }
}