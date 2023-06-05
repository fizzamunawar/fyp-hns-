using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fyp_hunger_nd_spice_.Models;

namespace fyp_hunger_nd_spice_.Controllers
{
    public class customersController : Controller
    {
        private Model db = new Model();

        // GET: customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_id,Customer_name,Customer_email,Customer_password,Customer_contact,Customer_address")] customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            return View(customer);
        }

        // GET: customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_id,Customer_name,Customer_email,Customer_password,Customer_contact,Customer_address")] customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult login(customer C)
        {
            customer c = db.Customers.Where(x => x.Customer_email==C.Customer_email&& x.Customer_password==C.Customer_password).FirstOrDefault();
            if (c !=null)
            {
                Session["customer"]=c;
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                ViewBag.message="Invalid Email or password";
                return View();
            }
        }
            public ActionResult logout()
            {
                Session["customer"]= null;
                return RedirectToAction("indexcustomer","home");
            }
         public ActionResult HISTORY()
            {
                return View();
            }
        public ActionResult SaleInvoice(int id)
        {
            var o = db.Orders.Where(x => x.Order_ID==id).ToList();

            return View(o);
        } public ActionResult Cancel(int id)
        {
           Order o = db.Orders.Where(x => x.Order_ID==id).FirstOrDefault();
            o.Order_status ="Cancel";

            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("HISTORY");
        }




    }
}
