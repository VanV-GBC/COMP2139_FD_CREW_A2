using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class CustomerController : Controller
    {

        private Repository<Customer> data { get; set; }
        /*private List<Country> countries;*/


        public CustomerController(SportsProContext contx) => data = new Repository<Customer>(contx);

        //[Route("/")]
        public IActionResult Index() => RedirectToAction("List");

        //----------------------List View


        // List GET method - gets list view.

        [HttpGet]
        [Route("Customers")]
        public IActionResult List(string id = "All")
        {
            List<Customer> customers;
            if (id == "All")
            {
                customers = (List<Customer>) data.List(new QueryOptions<Customer>
                {
                    OrderBy = c => c.CustomerId
                });
            }
            else
            {
                // same thing, reaching this ideally shouldn't be possible.
                customers = (List<Customer>)data.List(new QueryOptions<Customer>
                {
                    OrderBy = c => c.CustomerId
                });
            }

            ViewBag.CurrentPages = "Customer";
            return View("CustomerList", customers);
        }



        //----------------------Add Customer

        // GET - gets add customer view
        [HttpGet]
        //[Route("{controller=Home}/{action=Add}/{id?}")]
        public IActionResult Add()
        {
            Customer customer = new Customer();
            ViewBag.Action = "Add";
            ViewBag.Countries = countries;
            ViewBag.CurrentPages = "Customer";
            return View("CustomerEdit", customer);
        }

        // POST - adds customer
        [HttpPost]
        public IActionResult Add(Customer customer)
        {


            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(data, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(customer);
                data.Save();
                TempData["message"] = $"{customer.FirstName} {customer.LastName} Was Added to Database.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Customer";
                TempData["message"] = $"Addition of {customer.FirstName} {customer.LastName} failed";
                return View("CustomerEdit", customer);
            }

        }

        //----------------------Edit Customer

        // GET - gets edit customer view
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Customer customer = data.Get(id);
            ViewBag.Action = "Edit";
            ViewBag.CurrentPages = "Customer";
            return View("CustomerEdit", customer);

        }

        // POST - edit customer
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(data, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                data.Update(customer);
                data.Save();
                TempData["message"] = $"{customer.FirstName} {customer.LastName} Was Edited.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Customer";
                TempData["message"] = $"Addition of {customer.FirstName} {customer.LastName} failed";
                return View("CustomerEdit", customer);
            }
        }


        //----------------------Delete Customer 


        //----------------------Delete Product
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = data.Get(id);
            ViewBag.CurrentPages = "Customer";
            return View("CustomerDelete", customer);
        }

        // POST - deletes customer
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            data.Delete(customer);
            TempData["message"] = $"Id: {customer.CustomerId}, {customer.FirstName} {customer.LastName} deleted";
            data.Save();
            return RedirectToAction("List");
        }

    }
}