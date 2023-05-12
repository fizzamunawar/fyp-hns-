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
    public class productsController : Controller
    {
        private Model db = new Model();
        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.category_fid = new SelectList(db.Categories, "Cat_ID", "Cusinie_name");
            ViewBag.Products_id = new SelectList(db.products, "Products_id", "Products_name");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product product)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(product.Pro.FileName,product.Pro.InputStream)
              
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            product.Products_pic = uploadResult.Url.ToString();
            db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            ViewBag.category_fid = new SelectList(db.Categories, "Cat_ID", "Cusinie_name", product.category_fid);
            ViewBag.Products_id = new SelectList(db.products, "Products_id", "Products_name", product.Products_id);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            
            product product = db.products.Find(id);
            ViewBag.category_fid = new SelectList(db.Categories, "Cat_ID", "Cusinie_name", product.category_fid);
            ViewBag.Products_id = new SelectList(db.products, "Products_id", "Products_name", product.Products_id);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product product)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(product.Pro.FileName, product.Pro.InputStream)

            };

            var uploadResult = cloudinary.Upload(uploadParams);
            product.Products_pic = uploadResult.Url.ToString();
            db.products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.category_fid = new SelectList(db.Categories, "Cat_ID", "Cusinie_name", product.category_fid);
            ViewBag.Products_id = new SelectList(db.products, "Products_id", "Products_name", product.Products_id);
            return View(product);
        
        }
        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
