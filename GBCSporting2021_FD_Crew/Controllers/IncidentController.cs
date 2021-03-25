using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace COMP2139_FD_CREW.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context;
        private List<Product> products;
        private List<Technician> technicians;
        private List<Customer> customers;
        private IEnumerable<SelectListItem> customerList;

        public IncidentController(SportsProContext contx)
        {
            context = contx;
            products = context.Products
                    .OrderBy(p => p.ProductId)
                    .ToList();
            technicians = context.Technicians
                    .OrderBy(t => t.TechnicianId)
                    .ToList();
            customers = context.Customers
                    .OrderBy(c => c.CustomerId)
                    .ToList();
            customerList = from c in customers
                           select new SelectListItem
                           {
                               Text = c.FirstName + " " + c.LastName,
                               Value = c.CustomerId.ToString()
                           };
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]
        public IActionResult List(string id = "All")
        {
            List<Incident> incidents;
            if (id == "All")
            {
                incidents = context.Incidents
                    .OrderBy(p => p.IncidentId)
                    .ToList();
                foreach (var item in incidents)
                {
                    item.Customer = context.Customers
                        .FirstOrDefault(c => c.CustomerId == item.CustomerId);
                    item.Product = context.Products
                        .FirstOrDefault(p => p.ProductId == item.ProductId);
                    item.Technician = context.Technicians
                        .FirstOrDefault(t => t.TechnicianId == item.TechnicianId);
                }
            }
            else
            {
                // experimenting here
                incidents = context.Incidents
                    .Where(i => i.Title == id)
                    .OrderBy(t => t.TechnicianId)
                    .ToList();
            }
            ViewBag.CurrentPages = "Incident";
            return View("IncidentList", incidents);
        }


        //----------------------Add Incident

        // GET - gets add incident view 
        [HttpGet]
        public IActionResult Add()
        {
            Incident incident = new Incident();

            
            incident.Product = context.Products.Find(1);
            incident.Technician = context.Technicians.Find(1);
            incident.Customer = context.Customers.Find(1);
            ViewBag.Action = "Add";
            ViewBag.Products = products;
            ViewBag.Technicians = technicians;
            ViewBag.Customers = customers;
            ViewBag.CustomerList = customerList;
            ViewBag.CurrentPages = "Incident";
            return View("IncidentEdit", incident);
        }

        // POST - adds incident
        [HttpPost]
        public IActionResult Add(Incident incident)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                incident.Product = context.Products.Find(1);
                incident.Technician = context.Technicians.Find(1);
                incident.Customer = context.Customers.Find(1);
                ViewBag.Action = "Add";
                ViewBag.Products = products;
                ViewBag.Technicians = technicians;
                ViewBag.Customers = customers;
                ViewBag.CustomerList = customerList;
                ViewBag.CurrentPages = "Incident";
                return View("IncidentEdit", incident);
            }
        }


        //----------------------Edit Incident

        // GET - gets edit incident view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident incident = context.Incidents
                .Include(i => i.Product)
                .Include(i => i.Customer)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);

            ViewBag.Action = "Edit";
            ViewBag.Products = products;
            ViewBag.Technicians = technicians;
            ViewBag.Customers = customers;
            ViewBag.CustomerList = customerList;
            ViewBag.CurrentPages = "Incident";
            return View("IncidentEdit", incident);

        }

        // POST - edit incident

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                incident.Product = context.Products.Find(1);
                incident.Technician = context.Technicians.Find(1);
                incident.Customer = context.Customers.Find(1);

                ViewBag.Action = "Edit";
                ViewBag.Products = products;
                ViewBag.Technicians = technicians;
                ViewBag.Customers = customers;
                ViewBag.CustomerList = customerList;
                ViewBag.CurrentPages = "Incident";
                return View("IncidentEdit", incident);
            }
        }


        //----------------------Delete Incident


        // GET - gets delete incident view
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Incident incident = context.Incidents
                 .FirstOrDefault(i => i.IncidentId == id);
            ViewBag.CurrentPages = "Incident";
            return View("IncidentDelete", incident);
        }

        // DELETE - deletes incident 
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
