using fyp_hunger_nd_spice_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp_hunger_nd_spice_.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        private Model db = new Model();
        public ActionResult Parchasereport()
        {
            var o = db.Orders.Where(x=>x.Order_type=="Purchase").ToList();
            return View(o);
        } 
        public ActionResult Salereport()
        {
            var o = db.Orders.Where(x=>x.Order_type=="Sale").ToList();
            return View(o);
        }
        public ActionResult Invoice(int id)
        {
            var o = db.Orders.Where(x => x.Order_ID==id).ToList();

            return View(o);
        }  
        public ActionResult SaleInvoice(int id)
        {
            var o = db.Orders.Where(x => x.Order_ID==id).ToList();

            return View(o);
        } 
        public ActionResult waitersreport()
        {

            var p = db.Employee.Where(x => x.Employee_Role=="Waiter").ToList();
            return View(p);
        } 
        public ActionResult Chefreport()
        {

            var p = db.Employee.Where(x => x.Employee_Role=="Chef").ToList();
            return View(p);
        } public ActionResult CSreport()
        {

            var p = db.Employee.Where(x => x.Employee_Role=="Cleaning staff").ToList();
            return View(p);
        } public ActionResult Deliverymanreport()
        {

            var p = db.Employee.Where(x => x.Employee_Role=="Deliveryman").ToList();
            return View(p);
        }public ActionResult employeereport()
        {

            var p = db.Employee.ToList();
            return View(p);
        }
    }
}