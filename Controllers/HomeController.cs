using fyp_hunger_nd_spice_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp_hunger_nd_spice_.Controllers
{
   

    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Indexcustomer()
        {
            return View();
        } public ActionResult Indexadmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult login()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult login(Models.admin A)
        {
           int result= db.admins.Where(x => x.Admin_email==A.Admin_email && x.Admin_password==A.Admin_password).Count();
            if (result==1)
            {
                return RedirectToAction("indexadmin", "Home");
            }
            else
            {
                ViewBag.message="Invalid Email or password";
                return View();
            }
           
        }
    }
}