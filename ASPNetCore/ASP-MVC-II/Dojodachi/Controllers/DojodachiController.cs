
using Dojodachi.Models;
using Dojodachi.SessionHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojodachi.Controolers
{
    public class DojodachiController : Controller
    {
        [HttpGet("")]
        public RedirectToActionResult Landing()
        {
            MyDojodachi myPet = new MyDojodachi();
            HttpContext.Session.SetObjectAsJson("MyPet", myPet);
            return RedirectToAction("Main");
        }

        [HttpGet("dojodachi")]
        public ViewResult Main()
        {
            MyDojodachi Retrieve = HttpContext.Session.GetObjectFromJson<MyDojodachi>("MyPet");
            ViewBag.Reaction = "Hi! let's do something..";
            ViewBag.Fullness = Retrieve.Fullness;
            ViewBag.Happiness = Retrieve.Happiness;
            ViewBag.Meals = Retrieve.Meals;
            ViewBag.Energy = Retrieve.Energy;
            ViewBag.Status = "alive";
            return View("Index");
        }

        [HttpPost("feed")]
        public ViewResult Feed()
        {
            MyDojodachi Retrieve = HttpContext.Session.GetObjectFromJson<MyDojodachi>("MyPet");
            ViewBag.Reaction = Retrieve.Feed();
            ViewBag.Activity = "eat";
            return CheckStatus(Retrieve);
        }

        
        [HttpPost("play")]
        public ViewResult Play()
        {
            MyDojodachi Retrieve = HttpContext.Session.GetObjectFromJson<MyDojodachi>("MyPet");
            ViewBag.Reaction = Retrieve.Play();
            ViewBag.Activity = "play";
            return CheckStatus(Retrieve);
        }

        [HttpPost("work")]
        public ViewResult Work()
        {
            MyDojodachi Retrieve = HttpContext.Session.GetObjectFromJson<MyDojodachi>("MyPet");
            ViewBag.Reaction = Retrieve.Work();
            ViewBag.Activity = "work";
            return CheckStatus(Retrieve);
        }

        [HttpPost("sleep")]
        public ViewResult Sleep()
        {
            MyDojodachi Retrieve = HttpContext.Session.GetObjectFromJson<MyDojodachi>("MyPet");
            ViewBag.Reaction = Retrieve.Sleep();
            ViewBag.Activity = "sleep";
            return CheckStatus(Retrieve);
        }

        [HttpPost("restart")]
        public RedirectToActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Landing");
        }

        public ViewResult CheckStatus( MyDojodachi Retrieve)
        {
            ViewBag.Fullness = Retrieve.Fullness;
            ViewBag.Happiness = Retrieve.Happiness;
            ViewBag.Meals = Retrieve.Meals;
            ViewBag.Energy = Retrieve.Energy;
            HttpContext.Session.SetObjectAsJson("MyPet", Retrieve);
            if(!Retrieve.Alive)
            {
                ViewBag.Reaction = "Your Dojoachi has passed away...";
                ViewBag.Status = "lost";
                ViewBag.Activity = "dead";
                return View("Index");
            }
            if(Retrieve.Win)
            {
                ViewBag.Reaction = "Congratulations! You won!";
                ViewBag.Status = "won";
                ViewBag.Activity = "won";
                return View("Index");
            }
            ViewBag.Status = "alive";
            return View("Index");
        }

    }
}