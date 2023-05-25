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
    public class IngredientsController : Controller
    {
        private Model db = new Model();

        // GET: Ingredients
        public ActionResult Index()
        {
            var ingredients = db.Ingredients.Include(i => i.Cat);
            return View(ingredients.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.Cat_fid = new SelectList(db.Cats, "Cate_ID", "Cat_name");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingredient ingredient)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(ingredient.ing.FileName, ingredient.ing.InputStream)

            };

            var uploadResult = cloudinary.Upload(uploadParams);
            ingredient.ingredient_pic= uploadResult.Url.ToString();
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.ingredient.Cat_fid = new SelectList(db.Cats, "Cate_ID", "Cat_name", ingredient.Cat_fid);
            ViewBag.ingredient_id = new SelectList(db.Ingredients, "Ingredients_id", "Ingredient_name", ingredient.ingredient_id)
            {

            };
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_fid = new SelectList(db.Cats, "Cate_ID", "Cat_name", ingredient.Cat_fid);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingredient ingredient)
        {
            var cloudinary = new Cloudinary(new Account("dzvreuvgg", "243827289115876", "z69DbUjGXjwNHpCbS5G3kueEweo"));

            // Upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(ingredient.ing.FileName, ingredient.ing.InputStream)

            };

            var uploadResult = cloudinary.Upload(uploadParams);
            ingredient.ingredient_pic= uploadResult.Url.ToString();
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.ingredient.Cat_fid = new SelectList(db.Cats, "Cate_ID", "Cat_name", ingredient.Cat_fid);
            ViewBag.ingredient_id = new SelectList(db.Ingredients, "Ingredients_id", "Ingredient_name", ingredient.ingredient_id)
            {

            };
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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
