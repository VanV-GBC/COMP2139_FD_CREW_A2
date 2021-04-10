using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;
using Microsoft.EntityFrameworkCore;


namespace GBCSporting2021_FD_Crew.Controllers
{
    public class TechIncidentController : Controller
    {

        private SportsProContext context;
        private List<Product> products;
        private List<Technician> technicians;
        private List<Customer> customers;

        public TechIncidentController(SportsProContext contx)
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
        }

        public IActionResult Index()
        {
            return RedirectToAction("Get", "TechIncident");
        }


        //----------------------Select Tech
        [HttpGet]
        public IActionResult Get(int id)
        {
            var i = context.Incidents.Find(id);
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            return View(i);
        }


        [HttpPost]
        public IActionResult List(int TechnicianId)
        {
            List<Incident> incidents = new List<Incident>();
            IQueryable<Incident> query = context.Incidents
                .Where(t => t.TechnicianId == TechnicianId).Include(i => i.Customer).Include(i => i.Product);

            incidents = query.ToList();
            return View(incidents);
        }
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
                incident.Product = context.Products.Find(incident.IncidentId);
                incident.Technician = context.Technicians.Find(incident.IncidentId);
                incident.Customer = context.Customers.Find(incident.IncidentId);

                ViewBag.Action = "Edit";
                ViewBag.Products = products;
                ViewBag.Technicians = technicians;
                ViewBag.Customers = customers;

                return View("IncidentEdit", incident);
            }
        }


    }
}
