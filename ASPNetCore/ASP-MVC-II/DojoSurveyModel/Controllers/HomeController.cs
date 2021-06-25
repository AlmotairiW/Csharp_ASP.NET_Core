using DojoSurveyModel.Models;
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

            return View("Display", survey);

        }
    }
}