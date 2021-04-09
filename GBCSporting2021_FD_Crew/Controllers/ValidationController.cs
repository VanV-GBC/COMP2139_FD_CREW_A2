using Microsoft.AspNetCore.Mvc;
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew.Controllers
{
    public class ValidationController : Controller
    {
        private SportsProContext context;
        public ValidationController(SportsProContext ctx) => context = ctx;
       
        public JsonResult CheckEmail(string emailAddy)
        {
            string msg = Check.EmailExists(context, emailAddy);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
