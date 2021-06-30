using System;
using System.Collections.Generic;
using System.Linq;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDelicious.Controllers
{
    public class DishController : Controller
    {
        private MyContext _context;

        public DishController(MyContext context)
        {
            _context = context;
        }
        
        [HttpGet("")]
        public ViewResult Index()
        {
            List<Dish> AllDishes = _context.Dishes
            .OrderByDescending(d => d.CreatedAt)
            .ToList();
            return View(AllDishes);
        }

        [HttpGet("new")]
        public ViewResult AddDish()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDish);  
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddDish");
        }

        [HttpGet("{id}")]
        public ViewResult DishDetail(int id)
        {
            Dish thisDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);

            return View(thisDish);
        }

        [HttpGet("edit/{id}")]
        public ViewResult EditDish(int id)
        {
            Dish thisDish = _context.Dishes.FirstOrDefault( d => d.DishId == id);
            return View(thisDish);
        }
        
        [HttpPost("update/{id}")]
        public IActionResult Update(Dish thisDish, int id)
        {
            if(ModelState.IsValid)
            {
                Dish dishToUpdate = _context.Dishes.FirstOrDefault( d => d.DishId == id);
                dishToUpdate.Name = thisDish.Name;
                dishToUpdate.Chef = thisDish.Chef;
                dishToUpdate.Calories = thisDish.Calories;
                dishToUpdate.Tastines = thisDish.Tastines;
                dishToUpdate.Description = thisDish.Description;
                dishToUpdate.UpdateddAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            thisDish.DishId = id;
            return View("EditDish", thisDish);
        }

        [HttpGet("delete/{id}")]
        public RedirectToActionResult Delete(int id)
        {
            Dish dishToDelete = _context.Dishes.FirstOrDefault(d => d.DishId == id);
            _context.Dishes.Remove(dishToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}