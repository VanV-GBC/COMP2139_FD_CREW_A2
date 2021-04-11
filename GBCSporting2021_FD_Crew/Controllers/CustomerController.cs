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
      
        private CustomerUnitOfWork data { get; set; }
        public CustomerController(SportsProContext contx) =>
            data = new CustomerUnitOfWork(contx);


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
                customers = (List<Customer>) data.Customers.List(new QueryOptions<Customer> { 
                    OrderBy = c => c.CustomerId
                });
            }
            else
            {
                customers = (List<Customer>)data.Customers.List(new QueryOptions<Customer>
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
        public IActionResult Add()
        {
            Customer customer = new Customer();
            ViewBag.Action = "Add";
            ViewBag.Countries = data.Countries.List(new QueryOptions<Country> { 
                OrderBy = c => c.CountryId
            });
            ViewBag.CurrentPages = "Customer";
            return View("CustomerEdit", customer);
        }

        // POST - adds customer
        [HttpPost]
        public IActionResult Add(Customer customer)
        {


            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(data.GetContext(), customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                data.Customers.Insert(customer);
                data.Customers.Save();
                TempData["message"] = $"{customer.FirstName} {customer.LastName} Was Added to Database.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Customer";
                ViewBag.Countries = data.Countries.List(new QueryOptions<Country>
                {
                    OrderBy = c => c.CountryId
                });
                TempData["message"] = $"Addition of {customer.FirstName} {customer.LastName} failed";
                return View("CustomerEdit", customer);
            }

        }

        //----------------------Edit Customer

        // GET - gets edit customer view
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Customer customer = data.Customers.Get(id);
            ViewBag.Action = "Edit";
            ViewBag.Countries = data.Countries.List(new QueryOptions<Country>
            {
                OrderBy = c => c.CountryId
            });
            ViewBag.CurrentPages = "Customer";
            return View("CustomerEdit", customer);

        }

        // POST - edit customer
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                data.Customers.Update(customer);
                data.Customers.Save();
                TempData["message"] = $"{customer.FirstName} {customer.LastName} Was Edited.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                ViewBag.CurrentPages = "Customer";
                ViewBag.Countries = data.Countries.List(new QueryOptions<Country>
                {
                    OrderBy = c => c.CountryId
                });
                TempData["message"] = $"Edit of {customer.FirstName} {customer.LastName} failed";
                return View("CustomerEdit", customer);
            }
        }


        //----------------------Delete Customer 


        //----------------------Delete Product
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = data.Customers.Get(id);
            ViewBag.CurrentPages = "Customer";
            return View("CustomerDelete", customer);
        }

        // POST - deletes customer
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            data.Customers.Delete(customer);
            TempData["message"] = $"Id: {customer.CustomerId}, {customer.FirstName} {customer.LastName} deleted";
            data.Customers.Save();
            return RedirectToAction("List");
        }

    }
}