using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;


namespace GBCSporting2021_FD_Crew.Controllers
{
    public class TechIncidentController : Controller
    {

        private SportsProContext context;

        public TechIncidentController(SportsProContext contx)
        {
            context = contx;
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
        public IActionResult List(Incident incident)
        {
            var i = context.Incidents.Where(t => t.TechnicianId == incident.TechnicianId).ToList();
            return View(i);
        }
        // GET - gets edit incident view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident incident = context.Incidents
                .FirstOrDefault(i => i.IncidentId == id);
            List<Customer> customers = context.Customers.ToList();
            List<Product> products = context.Products.ToList();
            List<Technician> technicians = context.Technicians.ToList();
            IncidentEditModel data = new IncidentEditModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                Action = "Edit",
                Incident = incident
            };
            return View("IncidentEdit", data);

        }

        // POST - edit incident

        [HttpPost]
        public IActionResult Edit(IncidentEditModel data)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Update(data.Incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                List<Customer> customers = context.Customers.ToList();
                List<Product> products = context.Products.ToList();
                List<Technician> technicians = context.Technicians.ToList();
                data.Customers = customers;
                data.Products = products;
                data.Technicians = technicians;
                data.Action = "Edit";
                return View("IncidentEdit", data);
            }
        }

    }
}
