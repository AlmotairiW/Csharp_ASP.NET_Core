using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers
{
    public class FoodController : Controller
    {
        [HttpGet("")]
        public ViewResult List()
        {

            return View("FoodList");
        }
    }
}