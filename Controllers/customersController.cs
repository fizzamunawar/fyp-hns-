using System;
using System.Net.Mail;
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
            // Check if the email address is already registered
            var existingCustomer = db.Customers.FirstOrDefault(c => c.Customer_email == customer.Customer_email);
            if (existingCustomer != null)
            {
                ModelState.AddModelError("Customer_email", "This email address is already registered.");
                return View(customer);
            }

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
            if (c != null)
            {
                Session["customer"] = c;
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                ViewBag.message = "Invalid Email or password";
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

        // CustomersController.cs
      
        public ActionResult forgotpassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult forgotpassword(customer customerEmail)
      
            {
            // Find the customer in the database based on the provided email
            var customer = db.Customers.Where(x=>x.Customer_email==customerEmail.Customer_email).FirstOrDefault();

                if (customer != null)
                {
                // Generate a unique code for password reset (e.g., using Guid.NewGuid())
                Random random = new Random();
                int randomNumber = random.Next(100000, 999999); // Generate a random number between 100000 and 999999
                string uniqueCode = randomNumber.ToString();

                // Save the reset code to the customer's record in the database
                customer.ResetCode = uniqueCode;
                db.SaveChanges();


                // Send an email to the customer with the password reset link
                string resetLink = Url.Action("Resetpassword", "customers", new { code = uniqueCode }, Request.Url.Scheme);

                MailMessage mail = new MailMessage();
                mail.From= new MailAddress("Fizzamunawar227@gmail.com");
                mail.To.Add(new MailAddress(customerEmail.Customer_email));
                
               
                mail.Subject = "Password Reset"; // Set the email subject
                mail.Body = $"Please reset your password using the following link: {resetLink}"; // Set the email body

                // Configure the SMTP
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("Fizzamunawar227@gmail.com", "qnfjwnpncjrviwsv");
                SmtpServer.Send(mail);
                // Use an email library or service to send the email, providing the resetLink in the email body
            }

                // Display a confirmation message or error message to the user on the ForgotPassword view
                ViewBag.Message = "A password reset email has been sent if the email exists in our system.";

                return View("forgotpassword");

            
            

          
        }
        public ActionResult Resetpassword(string code)
        {
            // Find the customer in the database based on the provided reset code
            var customer = db.Customers.FirstOrDefault(c => c.ResetCode == code);

            if (customer != null)
            {
                // Pass the reset code to the view so it can be included in the form submission
                ViewBag.ResetCode = code;

                return View("Resetpassword");
            }

            // Display an error message if the reset code is invalid or expired
            ViewBag.Message = "Invalid reset code.";
            return View("forgotpassword");
        }
        [HttpPost]
        public ActionResult Resetpassword(string resetCode, string newPassword)
        {
            // Find the customer in the database based on the provided reset code
            var customer = db.Customers.FirstOrDefault(c => c.ResetCode == resetCode);

            if (customer != null)
            {
                // Update the customer's password with the new password
                customer.Customer_password = newPassword;
                customer.ResetCode = null; // Clear the reset code
                db.SaveChanges();

                // Display a confirmation message to the user
                ViewBag.Message = "Password reset successful. You can now log in with your new password.";

                // Redirect the user to the login page or any other appropriate page
                return RedirectToAction("Login", "Customers");
            }

            // Display an error message if the reset code is invalid or expired
            ViewBag.Message = "Invalid reset code.";
            return View("Resetpassword");
        }





    }
}
