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

        private IncidentUnitOfWork workdata { get; set; }
        public IncidentController(SportsProContext contx) =>
            workdata = new IncidentUnitOfWork(contx);

        /*private SportsProContext context;

        public IncidentController(SportsProContext contx)
        {
            context = contx;
        }*/

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]

        [Route("Incidents")]
        public IActionResult List(string filter = "all")
        {
            var data = new IncidentListViewModel();
            List<Incident> incidents = new List<Incident>();

            var query = workdata.Incidents.List(new QueryOptions<Incident> { 
                Includes = "Customer, Product"
            });
/*
            
            IQueryable<Incident> query = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product);
*/
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
            List<Customer> customers = new List<Customer>();
            List<Product> products = (List<Product>) workdata.Products.List(new QueryOptions<Product> { 
                OrderByDirection = "asc"
            });
            List<Technician> technicians = (List<Technician> )workdata.Technicians.List( new QueryOptions<Technician> { 
                OrderByDirection = "asc"
            });
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
                workdata.Incidents.Insert(data.Incident);
                workdata.Incidents.Save();
                TempData["message"] = $"{data.Incident.Title} Was Added.";
                return RedirectToAction("List");
            }
            else
            {
                List<Customer> customers = (List<Customer>)workdata.Customers.List(new QueryOptions<Customer>
                {
                    OrderByDirection = "asc"
                });

                List<Product> products = (List<Product> ) workdata.Products.List(new QueryOptions<Product>
                {
                    OrderByDirection = "asc"
                });

                List<Technician> technicians = (List<Technician>)workdata.Technicians.List(new QueryOptions<Technician>
                {
                    OrderByDirection = "asc"
                });

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


            Incident incident = workdata.Incidents.Get(id);

            /*            Incident incident = context.Incidents
                            .Include(i => i.Product)
                            .Include(i => i.Customer)
                            .Include(i => i.Technician)
                            .FirstOrDefault(i => i.IncidentId == id);*/

            List<Customer> customers = (List<Customer>) workdata.Customers.List(new QueryOptions<Customer> { 
                OrderByDirection = "asc"
            });
            List<Product> products = (List<Product>) workdata.Products.List(new QueryOptions<Product>
            {
                OrderByDirection = "asc"
            });
            List<Technician> technicians = (List<Technician>)workdata.Technicians.List(new QueryOptions<Technician>
            {
                OrderByDirection = "asc"
            });

/*            List<Product> products = context.Products.ToList();
            List<Technician> technicians = context.Technicians.ToList();*/
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
                workdata.Incidents.Update(data.Incident);
                workdata.Incidents.Save();
                TempData["message"] = $"{data.Incident.Title} Was Edited.";
                return RedirectToAction("List");
            }
            else
            {
                List<Customer> customers = (List<Customer>)workdata.Customers.List(new QueryOptions<Customer>
                {
                    OrderByDirection = "asc"
                });
                List<Product> products = (List<Product>)workdata.Products.List(new QueryOptions<Product>
                {
                    OrderByDirection = "asc"
                });
                List<Technician> technicians = (List<Technician>)workdata.Technicians.List(new QueryOptions<Technician>
                {
                    OrderByDirection = "asc"
                });
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
            Incident incident = workdata.Incidents.Get(id);
            ViewBag.CurrentPages = "Incident";
            return View("IncidentDelete", incident);
        }

        // DELETE - deletes incident 
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            TempData["message"] = $"{incident.Title} Was Deleted.";
            workdata.Incidents.Delete(incident);
            workdata.Incidents.Save();
            return RedirectToAction("List");
        }

    }
}
