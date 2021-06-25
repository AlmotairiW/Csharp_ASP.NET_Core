using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;
namespace ViewModelFun.Controllers
{
    public class FunController: Controller
    {
        [HttpGet("")]

        public ViewResult Message()
        {
            string msg = "Hello From The Other Side";
            return View("Message", msg);
        }

        [HttpGet("numbers")]
        public ViewResult Numbers()
        {
            int[] numbers = {1, 2, 3, 4, 20, 33, 7};
            return View(numbers);
        }

        [HttpGet("users")]

        public ViewResult Users()
        {
            List<User> users= new List<User> 
            {
                new User()
                {
                    FirstName = "Moose",
                    LastName = "Phillips",
                },
                new User()
                {
                    FirstName = "Sarah",
                },
                new User()
                {
                    FirstName = "Jerry",
                },
                new User()
                {
                    FirstName = "Rene",
                    LastName = "Ricky",
                },

                new User()
                {
                    FirstName = "Barbarh",
                },
            };
            return View(users);
        }

        [HttpGet("user")]
        public ViewResult OneUser()
        {
            User user = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };
            return View(user);
        }
    }
}