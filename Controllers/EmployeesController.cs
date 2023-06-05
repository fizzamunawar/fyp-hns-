using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fyp_hunger_nd_spice_.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace fyp_hunger_nd_spice_.Controllers
{
    public class EmployeesController : Controller
    {
        private Model db = new Model();

        // GET: Employees1
        public ActionResult Index()

        { 
            
                return View(db.Employee.ToList());
            
        }

        // GET: Employees1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(employee.Emp_pic.FileName, employee.Emp_pic.InputStream)

            };

            var uploadResult = cloudinary.Upload(uploadParams);
            employee.Employee_pic = uploadResult.Url.ToString();
            db.Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");


            
           
           
        }
        // GET: Employees1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(employee.Emp_pic.FileName, employee.Emp_pic.InputStream)

            };

            var uploadResult = cloudinary.Upload(uploadParams);
            employee.Employee_pic = uploadResult.Url.ToString();
            db.Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");



          
        }

        // GET: Employees1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
    }
}
