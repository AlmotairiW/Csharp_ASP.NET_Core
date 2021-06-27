
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;



namespace RPG.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.RandCode = RandomString();
            HttpContext.Session.SetInt32("Count", 1);
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View();
        }

        [HttpPost("/generate")]
        public ViewResult Generate()
        {
            ViewBag.RandCode = RandomString();
            HttpContext.Session.SetInt32("Count", (int)HttpContext.Session.GetInt32("Count") + 1);
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View("Index");
        }

        public string RandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomStr ="";
            Random rand = new Random();
            int count = 1;
            while(count <= 14)
            {
                randomStr += chars[rand.Next(chars.Length)];
                count++;
            }
            return randomStr;
        }

    }
}
