
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            List<Chef> allChefs = _context.Chefs.Include( c => c.DishesMade)
            .ToList();
            return View(allChefs);
        }

        [HttpGet("new")]
        public ViewResult AddChef()
        {
            return View();
        }

        [HttpPost("new")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        [HttpGet("dishes")]
        public ViewResult Dishes()
        {
            List<Dish> allDishes = _context.Dishes.Include( d => d.MadeBy)
            .ToList();
            return View(allDishes);
        }
        [HttpGet("dishes/new")]
        public ViewResult AddDish()
        {
            ViewBag.allChefs = _context.Chefs.ToList();
            return View();
        }
        
        [HttpPost("dishes/new")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            ViewBag.allChefs = _context.Chefs.ToList();
            return View("AddDish");
        }
    }
}
