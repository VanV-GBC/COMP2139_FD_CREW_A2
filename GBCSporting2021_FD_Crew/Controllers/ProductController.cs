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
        private Repository<Product> data { get; set; }


        public ProductController(SportsProContext contx) => data = new Repository<Product>(contx);


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
                products = (List<Product>) data.List(new QueryOptions<Product> { 
                    OrderBy = p => p.ProductId
                });
            }
            else
            {
                // same thing, reaching this ideally shouldn't be possible.
                products = (List<Product>)data.List(new QueryOptions<Product>
                {
                    OrderBy = p => p.ProductId
                });
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
                data.Insert(product);
                data.Save();
                TempData["message"] = $"{product.ProductName} Was Added to Database.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Product";
                TempData["message"] = $"{product.ProductName} add failed ";
                return View("ProductEdit", product);
            }
        }

        //----------------------Edit Product

        // GET - gets edit product view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //not sure about this
            Product product = data.Get(id);

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
                data.Update(product);
                data.Save();
                TempData["message"] = $"{product.ProductName} was Updated.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                ViewBag.CurrentPages = "Product";
                TempData["message"] = $"{product.ProductName} update failed.";
                return View("ProductEdit", product);
            }
        }


        //----------------------Delete Product
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = data.Get(id);
            ViewBag.CurrentPages = "Product";
            TempData["message"] = $"{product.ProductName} deleted";
            return View("ProductDelete", product);
        }

        // POST - deletes customer
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            string temp = product.ProductName;
            TempData["message"] = $"{temp} Was Deleted.";
            data.Delete(product);
            data.Save();
            return RedirectToAction("List");
        }
    }
}