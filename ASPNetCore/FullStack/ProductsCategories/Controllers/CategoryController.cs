using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers
{
    public class CategoryController : Controller
    {
        MyContext _context;

        public CategoryController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("categories")]
        public ViewResult Categories()
        {
            ViewBag.AllCategories = _context.Categories.ToList();
            return View();
        }

        [HttpPost("categories/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction ("Categories");
            }

            ViewBag.AllCategories = _context.Categories.ToList();
            return View("Categories");
        }

        [HttpGet("categories/{id}")]
        public ViewResult CategoryDetail(int id)
        {
            ViewBag.thisCat = _context.Categories
            .Include(c => c.AllProducts)
            .ThenInclude(cp => cp.ProductOnCategory)
            .FirstOrDefault( c => c.CategoryId == id);

            List<object> categoryProducts = new List<object>();

            foreach(Association cp in ViewBag.thisCat.AllProducts)
            {
                categoryProducts.Add(cp.ProductOnCategory);
            }
            List<Product> allProds = _context.Products.ToList();

            ViewBag.AllProducts = allProds.Except(categoryProducts);
            return View();
        }

        [HttpPost("category/products")]

        public IActionResult AddProductToCategory(Association newAssociation)
        {
            if(newAssociation.ProductId == 0) // Category already has all products
                return Redirect ($"/categories/{newAssociation.CategoryId}");

            _context.Associations.Add(newAssociation);
            _context.SaveChanges();

            return Redirect ($"/categories/{newAssociation.CategoryId}"); 
        }
    }
}