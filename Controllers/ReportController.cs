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
        private const string V = "Cancel";

        // GET: Report
        private Model db = new Model();
        public ActionResult Parchasereport(Filtermodel fm)
        {
            if (fm.DateFrom == null)
            {


                ViewBag.DateFrom= System.DateTime.Today.ToString("s");
                fm.DateFrom = System.DateTime.Today;

            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(fm.DateFrom).ToString("s");
            }

            if (fm.DateTo == null)
            {


                ViewBag.DateTo= System.DateTime.Now.ToString("s");
                fm.DateTo = System.DateTime.Now;

            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(fm.DateTo).ToString("s");

            }


            var o = db.Orders.Where(x => x.Order_type=="Purchase" & x.Order_date >= fm.DateFrom & x.Order_date <= fm.DateTo).ToList();
           
            return View(o);
        } 
        public ActionResult Salereport(Filtermodel fm)
        {

            if (fm.DateFrom == null)
            {


                ViewBag.DateFrom= System.DateTime.Today.ToString("s");
                fm.DateFrom = System.DateTime.Today;

            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(fm.DateFrom).ToString("s");
            }

            if (fm.DateTo == null)
            {


                ViewBag.DateTo= System.DateTime.Now.ToString("s");
                fm.DateTo = System.DateTime.Now;

            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(fm.DateTo).ToString("s");

            }


            
            var o = db.Orders.Where(x => x.Order_type =="Sale"  & x.Order_date >= fm.DateFrom & x.Order_date <= fm.DateTo).ToList();
            return View(o);
        } public ActionResult Profitnloss(Filtermodel fm)
        {

            if (fm.DateFrom == null)
            {


                ViewBag.DateFrom= System.DateTime.Today.ToString("s");
                fm.DateFrom = System.DateTime.Today;

            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(fm.DateFrom).ToString("s");
            }

            if (fm.DateTo == null)
            {


                ViewBag.DateTo= System.DateTime.Now.ToString("s");
                fm.DateTo = System.DateTime.Now;

            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(fm.DateTo).ToString("s");

            }


            
            var o = db.Orders.Where(x => x.Order_type=="Sale"  & x.Order_date >= fm.DateFrom & x.Order_date <= fm.DateTo).ToList();
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
        
      public ActionResult employeereport()
        {

            var p = db.Employee.ToList();
            return View(p);
        }
    }
}