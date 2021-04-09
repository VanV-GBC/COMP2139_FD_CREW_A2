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

        public IncidentController(SportsProContext contx)
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
        public IActionResult List(string filter = "all")
        {
            var data = new IncidentListViewModel();
            List<Incident> incidents = new List<Incident>();
            IQueryable<Incident> query = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product);

            if (filter == "all")
            {
                incidents = query.ToList();
            }else if (filter == "unassigned")
            {
                incidents = query.Where(i => i.TechnicianId == null).ToList();
            }else if (filter == "open")
            {
                incidents = query.Where(i => i.dateClosed == null).ToList();
            }
            data.Incidents = incidents;
            data.Filter = filter;
            return View("IncidentList", data);
        }


        //----------------------Add Incident

        // GET - gets add incident view 
        [HttpGet]
        public IActionResult Add()
        {
            List<Customer> customers = context.Customers.ToList();
            List<Product> products = context.Products.ToList();
            List<Technician> technicians = context.Technicians.ToList();
            IncidentEditModel data = new IncidentEditModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                Action = "Add",
                Incident = new Incident()
            };
            return View("IncidentEdit", data);
        }

        // POST - adds incident
        [HttpPost]
        public IActionResult Add(IncidentEditModel data)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Add(data.Incident);
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
                data.Action = "Add";

                return View("IncidentEdit", data);
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
