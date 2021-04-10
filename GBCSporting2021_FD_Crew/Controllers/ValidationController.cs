using Microsoft.AspNetCore.Mvc;
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class ValidationController : Controller
    {

        private Repository<Customer> data { get; set; }
        public ValidationController(SportsProContext contx) => data = new Repository<Customer>(contx);

        public JsonResult CheckEmail(string emailAddy)
        {
            string msg = Check.EmailExists(data, emailAddy);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
