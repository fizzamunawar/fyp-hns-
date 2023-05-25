using fyp_hunger_nd_spice_.Models;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;


namespace fyp_hunger_nd_spice_.Controllers
{


    public class HomeController : Controller
    {
        private Model db = new Model();
        public ActionResult Indexcustomer()
        {
            return View();
        }
        public ActionResult Indexadmin()
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
            int result = db.admins.Where(x => x.Admin_email==A.Admin_email && x.Admin_password==A.Admin_password).Count();
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

        public ActionResult cart()
        {
            return View();
        }
        public ActionResult Menu(int? id)
        {

            Menu m = new Menu();
            /* menu is a model have to  list cat or pro */
            m.cat= db.Categories.ToList();
            if (id==null)
                m.pro= db.products.ToList();
            else
                m.pro= db.products.Where(p => p.category_fid==id).ToList();
            return View(m);
        }

        public ActionResult addtocart(int id)
        {
            List<product> list;

            if (Session["mycart"] == null)
            {
                list=new List<product>();
            }
            else
            {
                list=(List<product>)Session["mycart"];

            }
            list.Add(db.products.Where(p => p.Products_id==id).FirstOrDefault());
            list[list.Count-1].pro_quan=1;
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }

        public ActionResult minus(int rowno)
        {
            List<product> list = (List<product>)Session["mycart"];

            list[rowno].pro_quan--;
            if (list[rowno].pro_quan<1)
            {
                list.RemoveAt(rowno);

            }
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
        public ActionResult plus(int rowno)
        {
            List<product> list = (List<product>)Session["mycart"];
            list[rowno].pro_quan++;
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
        public ActionResult remove(int rowno)
        {
            List<product> list = (List<product>)Session["mycart"];
            list.RemoveAt(rowno);
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
       
        
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult paynow(Order o)
        {
            o.Order_date=System.DateTime.Now;
            o.Order_type="Sale";
            o.Order_status="COD";
        
        

            Session["order"]=o;
            return RedirectToAction("orderbooked");
        }

        public ActionResult orderbooked()

        { Order o = (Order)Session["order"];
           


          /*
            string senderEmail = "fizzamunawar227@gmail.com";
            string recipientEmail = o.Order_Email;
            string subject = "Order Confirmation";
            string body = " <b>Hunger & Spice !</b> </br> Thanks for your order";

          //Create a MailMessage object
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

          // Create a SmtpClient object
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //Set the SMTP client properties
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("fizzamunawar227@gmail.com", "gcliobddrvgwtjvo");

           //Send the email
            smtpClient.Send(mailMessage);
            
            */

            db.Orders.Add(o);
            db.SaveChanges();

            List<product> P = (List<product>)Session["mycart"];
            for (int i = 0; i<P.Count; i++)
            {


                Orderdetail od = new Orderdetail();
                int OrderID = db.Orders.Max(u => u.Order_ID);
                od.Order_Fid=OrderID;
                od.Product_fid=P[i].Products_id;
                od.Quantity=P[i].pro_quan;
                od.price=P[i].Products_price;

                db.Orderdetails.Add(od);
                db.SaveChanges();
            }









            return View();
        }






    }
}
