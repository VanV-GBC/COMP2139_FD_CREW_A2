using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// this will need to be changed when it's renamed
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class ProductController : Controller
    {

        private SportsProContext context;

        public ProductController(SportsProContext contx)
        {
            context = contx;
        }


        public IActionResult Index()
        {
            

            return RedirectToAction("List");
        }

        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]

        [Route("Products")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;
            if (id == "All")
            {
                products = context.Products
                    .OrderBy(p => p.ProductId)
                    .ToList();
            }
            else
            {
                // experimenting here
                products = context.Products
                    .Where(p => p.ProductCode == id)
                    .OrderBy(p => p.ProductId)
                    .ToList();
            }

            ViewBag.CurrentPages = "Product";
            return View("ProductList", products);
        }


        //----------------------Add Product

        // GET - gets add product view
        [HttpGet]
        public IActionResult Add()
        {
            Product product = new Product();
            ViewBag.Action = "Add";
            ViewBag.CurrentPages = "Product";
            return View("ProductEdit", product);
        }

        // POST - adds product
        [HttpPost]
        public IActionResult Add(Product product)
        {

            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                TempData["message"] = $"{product.ProductName} Was Added to Database.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Product";
                return View("ProductEdit", product);
            }
        }

        //----------------------Edit Product

        // GET - gets edit product view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = context.Products
                .FirstOrDefault(p => p.ProductId == id);

            ViewBag.Action = "Edit";
            ViewBag.CurrentPages = "Product";
            return View("ProductEdit", product);
        }

        // POST - edit product
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                context.SaveChanges();
                TempData["message"] = $"{product.ProductName} Was Edited.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                ViewBag.CurrentPages = "Product";
                return View("ProductEdit", product);
            }
        }


        //----------------------Delete Product
        [HttpGet]
        public IActionResult Delete(int id)
        {

            Product product = context.Products
                .FirstOrDefault(p => p.ProductId == id);
            ViewBag.CurrentPages = "Product";
            return View("ProductDelete", product);
        }

        // POST - deletes customer
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            string temp = product.ProductName;
            TempData["message"] = $"{temp} Was Deleted.";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}