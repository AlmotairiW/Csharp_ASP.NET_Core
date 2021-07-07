using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Register");
        }

        
        [HttpPost("")]
        public IActionResult ProcessReg(User regUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == regUser.Email))
                {
                    ModelState.AddModelError("Email", "The Email is already in use!");
                    return View("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                _context.Users.Add(regUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("uid", regUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Register");
        }
        [HttpGet("login")]
        public ViewResult LogIn()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult ProcessLogin(LoginUser thisUser)
        {
            if (ModelState.IsValid)
            {
                User LoggedUser = _context.Users.FirstOrDefault(u => u.Email == thisUser.Email);
                if (LoggedUser != null)
                {
                    PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                    if (Hasher.VerifyHashedPassword(thisUser, LoggedUser.Password, thisUser.Password) != 0)
                    {
                        HttpContext.Session.SetInt32("uid", LoggedUser.UserId);
                        return RedirectToAction("Dashboard");
                    }
                }

                ModelState.AddModelError("Email", "Invalid login credentials!");
                return View("LogIn");
            }
            return View("LogIn");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogIn");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("LogIn");

            ViewBag.ThisUser = _context.Users.FirstOrDefault( u => u.UserId == HttpContext.Session.GetInt32("uid"));

            List<Wedding> AllWeddings = _context.Weddings
            .Include(w => w.PlannedBy)
            .Include( w => w.AllGuests)
            .ThenInclude(uw => uw.GuestOnWedding)
            .ToList();
            
            return View(AllWeddings);
        }

        [HttpGet("RSVP/{wedId}")]
        public IActionResult RSVP(int wedId)
        {
            int uid = (int)HttpContext.Session.GetInt32("uid");
            UserWedding newGuest = new UserWedding();
            newGuest.WeddingId = wedId;
            newGuest.UserId = uid;
            _context.UserWeddings.Add(newGuest);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");

        }

        [HttpGet("unRSVP/{wedId}")]
        public IActionResult unRSVP(int wedId)
        {
            int uid = (int)HttpContext.Session.GetInt32("uid");
            UserWedding guestToRemove = _context.UserWeddings
            .FirstOrDefault(uw => uw.WeddingId == wedId && uw.UserId == uid);
            _context.UserWeddings.Remove(guestToRemove);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");

        }
    }
}
