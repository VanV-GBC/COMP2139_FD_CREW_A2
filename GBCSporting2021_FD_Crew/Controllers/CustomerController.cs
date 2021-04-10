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

        private SportsProContext context;
        private List<Country> countries;

        public CustomerController(SportsProContext contx) 
        {
            context = contx;
            countries = context.Countries.OrderBy(c => c.CountryId).ToList();
        }

       [Route("/")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }


        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]

        [Route("Customers")]
        public IActionResult List(String id = "All")
        {



            List<Customer> customers;

            if (id == "All")
            {
                customers = context.Customers
                    .OrderBy(c => c.CustomerId).ToList();
            }
            else
            {
                customers = context.Customers
                    .Where(c => c.Country.CountryId == id)
                    .OrderBy(c => c.CustomerId).ToList();
            }
            ViewBag.CurrentPages = "Customer";
            ViewBag.Countries = countries;
            ViewBag.SelectedCountryName = id;

            return View("CustomerList", customers);
        }


        //----------------------Add Customer

        // GET - gets add customer view
        [HttpGet]
        //[Route("{controller=Home}/{action=Add}/{id?}")]
        public IActionResult Add()
        {
            Customer customer = new Customer();
            customer.Country = context.Countries.Find("CAN");
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
                string msg = Check.EmailExists(context, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg) ;
                }
            }
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                TempData["message"] = $"{customer.FirstName} Was Added.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.Countries = countries;
                ModelState.AddModelError("", "Please address the errors in the form.");
                return View("CustomerEdit", customer);
            }
        }

        //----------------------Edit Customer

        // GET - gets edit customer view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer customer = context.Customers
                .Include(c => c.CountryId)
                .FirstOrDefault(c => c.CustomerId == id);


            ViewBag.Action = "Edit";
            ViewBag.Countries = countries;
            ViewBag.CurrentPages = "Customer";
            return View("CustomerEdit", customer);
        }

        // POST - edit customer
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }
            if (ModelState.IsValid)
            {
                context.Customers.Update(customer);
                context.SaveChanges();
                TempData["message"] = $"{customer.FirstName} Was Edited.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                ViewBag.Countries = countries;
                ViewBag.CurrentPages = "Customer";
                return View("CustomerEdit", customer);
            };
        }


        //----------------------Delete Customer 


        // GET - gets delete customer view
        [HttpGet]
        public IActionResult Delete(int id)
        {

            Customer customer = context.Customers
                .FirstOrDefault(c => c.CustomerId == id);
            ViewBag.CurrentPages = "Customer";
            return View("CustomerDelete", customer);
        }

        // POST - deletes customer
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            string temp = customer.FirstName;
            TempData["message"] = $"{temp} Was Deleted.";
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}