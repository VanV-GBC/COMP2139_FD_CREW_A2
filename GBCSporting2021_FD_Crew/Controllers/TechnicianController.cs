using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class TechnicianController : Controller
    {

        private Repository<Technician> data { get; set; }


        public TechnicianController(SportsProContext contx) => data = new Repository<Technician>(contx); 


        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //----------------------List View

        // List GET method - gets list view.

        [HttpGet]
        [Route("Technicians")]
        public IActionResult List(string id = "All")
        {
            List<Technician> technicians;
            if (id == "All")
            {
                technicians = (List<Technician>)data.List(new QueryOptions<Technician>
                {
                    OrderBy = t => t.TechnicianId
                });
            }
            else
            {
                // same thing, reaching this ideally shouldn't be possible.
                technicians = (List<Technician>)data.List(new QueryOptions<Technician>
                {
                    OrderBy = t => t.TechnicianId
                });
            }

            ViewBag.CurrentPages = "Technician";
            return View("TechnicianList", technicians);
        }



        //----------------------Add Technician

        // GET - gets add technician view
        [HttpGet]
        public IActionResult Add()
        {
            Technician technician = new Technician();
            ViewBag.Action = "Add";
            ViewBag.CurrentPages = "Technician";
            return View("TechnicianEdit", technician);
        }

        // POST - adds technician
        [HttpPost]
        public IActionResult Add(Technician technician)
        {

            if (ModelState.IsValid)
            {
                data.Insert(technician);
                data.Save();
                TempData["message"] = $"{technician.Name} Was Added to Database.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Product";
                TempData["message"] = $"{technician.Name} add failed ";
                return View("TechnicianEdit", technician);
            }
        }

        //----------------------Edit Technician

        // GET - gets edit technician view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //not sure about this
            Technician technician = data.Get(id);

            ViewBag.Action = "Edit";
            ViewBag.CurrentPages = "Technician";
            return View("ProductEdit", technician);
        }

        // POST - edit technician
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                data.Update(technician);
                data.Save();
                TempData["message"] = $"{technician.Name} was edited.";
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.CurrentPages = "Product";
                TempData["message"] = $"{technician.Name} edit failed ";
                return View("TechnicianEdit", technician);
            }
        }

        //----------------------Delete Technician
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Technician technician = data.Get(id);
            ViewBag.CurrentPages = "Technician";
            return View("ProductDelete", technician);
        }

        // POST - deletes technician
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            string temp = technician.Name;
            TempData["message"] = $"{temp} Was Deleted.";
            data.Delete(technician);
            data.Save();
            return RedirectToAction("List");
        }

    }
}