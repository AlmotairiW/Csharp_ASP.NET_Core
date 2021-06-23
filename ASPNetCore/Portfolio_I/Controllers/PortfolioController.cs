using Microsoft.AspNetCore.Mvc;

namespace Portfolio_I.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index";
        }

        [HttpGet("/projects")]
        public string Projects()
        {
            return "This is my projects";
        }

        [HttpGet("/contact")]
        public string Contact()
        {
            return "This is my Contacts!";
        }
    }
}