using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers
{
    public class ProductController : Controller
    {
        MyContext _context;

        public ProductController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        [HttpGet("products")]
        public ViewResult Products()
        {
            ViewBag.AllProducts = _context.Products.ToList();
            return View();
        }

        [HttpPost("products/create")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction ("Products");
            }

            ViewBag.AllProducts = _context.Products.ToList();
            return View("Products");
        }

        [HttpGet("products/{id}")]
        public ViewResult ProductDetail(int id)
        {
            ViewBag.thisProd = _context.Products
            .Include(p => p.AllCategories)
            .ThenInclude( a => a.CategoryOfProduct)
            .FirstOrDefault( p => p.ProductId == id);

            List<object> productCategories = new List<object>();
            foreach(Association cp in ViewBag.thisProd.AllCategories)
            {
                productCategories.Add(cp.CategoryOfProduct);
            }

            List<Category> allCats = _context.Categories.ToList();
            // List<Category> allCats =_context.Categories.Where(cat => !categoryList.Contains(cat)).ToList();
            
            ViewBag.AllCategories = allCats.Except(productCategories);
            return View();
        }

        [HttpPost("/product/categories")]
        public IActionResult AddCategoryToProduct(Association newAssociation)
        {
            if(ModelState.IsValid)
            {
                if(newAssociation.CategoryId == 0) // Product is already in all categories
                    return Redirect($"/products/{newAssociation.ProductId}");

                _context.Associations.Add(newAssociation);
                _context.SaveChanges();
                return Redirect($"/products/{newAssociation.ProductId}");
            }
            return Redirect($"/products/{newAssociation.ProductId}");
        }
    }
}

