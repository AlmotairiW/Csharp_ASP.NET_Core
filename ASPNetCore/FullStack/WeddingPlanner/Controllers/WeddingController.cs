using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private MyContext _context;

        public WeddingController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("new")]
        public IActionResult AddWedding()
        {
            if(HttpContext.Session.GetInt32("uid") != null)
                return View();
            return Redirect("/login");
        }

        [HttpPost("new/wedding")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                newWedding.UserId = (int)HttpContext.Session.GetInt32("uid");
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                return Redirect($"/wedding/{newWedding.WeddingId}");
            }
            return View("AddWedding");
        }

        [HttpGet("wedding/{id}")]
        public ActionResult WeddingDetail(int id)
        {
            Wedding ThisWedding = _context.Weddings
            .Include( w => w.AllGuests)
            .ThenInclude(uw => uw.GuestOnWedding)
            .FirstOrDefault(w => w.WeddingId == id);
            return View(ThisWedding);
        }

        [HttpGet("delete/{wedId}")]
        public IActionResult DeleteWedding(int wedId)
        {
            Wedding wedToRemove = _context.Weddings.FirstOrDefault(w => w.WeddingId == wedId);

            _context.Remove(wedToRemove);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "User");
        }

    }
}