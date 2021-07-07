using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
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
                _context.Add(regUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("uid", regUser.UserId);
                return RedirectToAction("Transactions", new { id = regUser.UserId });


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
                        return RedirectToAction("Transactions", new { id = LoggedUser.UserId });
                    }
                }

                ModelState.AddModelError("Email", "Invalid login credentials!");
                return View("LogIn");
            }
            return View("LogIn");
        }

        [HttpGet("account/{id}")]
        public IActionResult Transactions(int id)
        {
            int? uid = HttpContext.Session.GetInt32("uid");
            if (uid == null)
                return RedirectToAction("LogIn");

            if (id != uid)
                return RedirectToAction("Transactions", new { id = uid });

            User thisUser = _context.Users.Include(u => u.TransactionsMade)
            .FirstOrDefault(u => u.UserId == id);
            ViewBag.UserTransactions = thisUser.TransactionsMade.OrderByDescending(t => t.CreatedAt).ToList();
            ViewBag.UserName = thisUser.FirstName;

            return View();
        }

        [HttpPost("account")]
        public IActionResult DepositWithdraw(Transaction newTransaction)
        {
            int? uid = HttpContext.Session.GetInt32("uid");
            User LoggedUser = _context.Users.Include(u => u.TransactionsMade)
            .FirstOrDefault(u => u.UserId == uid);
            ViewBag.UserTransactions = LoggedUser.TransactionsMade.OrderByDescending(t => t.CreatedAt).ToList();
            ViewBag.UserName = LoggedUser.FirstName;

            if (ModelState.IsValid)
            {
                double curBalance = 0;
                foreach (Transaction t in LoggedUser.TransactionsMade)
                {
                    curBalance += t.Amount;
                }
                if ((curBalance + newTransaction.Amount) < 0)
                {
                    ModelState.AddModelError("Amount", "You don not have enough balance to do this transaction!");
                    return View("Transactions");
                }

                newTransaction.UserId = (int)uid;
                _context.Transactions.Add(newTransaction);
                _context.SaveChanges();
                return RedirectToAction("Transactions", new { id = uid });
            }
            return View("Transactions");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogIn");
        }
    }
}
