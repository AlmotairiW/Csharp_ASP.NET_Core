using System;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class TimeController: Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}