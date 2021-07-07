using System.Linq;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LogReg.Controllers
{
    public class UserController : Controller
    {
        private MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult ProcessReg(User regUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == regUser.Email))
                {
                    ModelState.AddModelError("Email", "The Email is already in use!");
                    return View("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                _context.Add(regUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("uid", _context.Users.First(u => u.Email == regUser.Email).UserId);
                return RedirectToAction("Success");
                
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
            if(ModelState.IsValid)
            {
                User LoggedUser = _context.Users.FirstOrDefault(u => u.Email == thisUser.Email);
                if(LoggedUser != null)
                {
                    PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                    if(Hasher.VerifyHashedPassword(thisUser, LoggedUser.Password, thisUser.Password) != 0)
                    {
                        HttpContext.Session.SetInt32("uid", LoggedUser.UserId);
                        return RedirectToAction("Success");
                    }
                }

                ModelState.AddModelError("Email", "Invalid login credentials!");
                return View("LogIn");
            }
            return View("LogIn");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("uid") != null)
            {
                User LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uid"));
                return View(LoggedUser);
            }
                
            return RedirectToAction("LogIn");
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogIn");
        }
    }
}