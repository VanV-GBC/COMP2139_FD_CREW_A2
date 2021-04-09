using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


// this will need to be changed when it's renamed
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class RegistrationController : Controller
    {
        //----------------------List View


        // List GET method - gets list view
        [HttpGet]

        [Route("Registration")]
        public IActionResult List()
        {
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationList");
        }


        //----------------------Add Registration

        // GET - gets add registration view
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Registration";
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationEdit");
        }

        // POST - adds registration
        [HttpPost]
        public IActionResult Add(Registration model)
        {
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationEdit");
        }

        //----------------------Edit Registration

        // GET - gets edit registration view
        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.CurrentPages = "Registration";
            ViewBag.Title = "Edit Registration";
            return View("RegistrationEdit");
        }

        // POST - edit registration - incomplete
        [HttpPost]
        public IActionResult Edit(Registration model)
        {
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationEdit");
        }


        //----------------------Delete Registration 


        // GET - gets delete registration view
        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationDelete");
        }

        // DELETE - deletes registration 
        [HttpDelete]
        public IActionResult Delete(Registration model)
        {
            ViewBag.CurrentPages = "Registration";
            return View("RegistrationDelete");
        }
    }
}
