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


    public class parchaseController : Controller
    {
        private Model db = new Model();
      
      

        public ActionResult cart()
        {
            return View();
        }
        public ActionResult parchase(int? id)
        {

            Menu m = new Menu();
            /* menu is a model have to  list cat or pro */
            m.cate= db.Cats.ToList();
            if (id==null)
                m.ingr= db.Ingredients.ToList();
            else
                m.ingr= db.Ingredients.Where(p => p.Cat_fid==id).ToList();
            return View(m);
        }

        public ActionResult addtocart(int id)
        {
            List<Ingredient> list;
           if (Session["mycart"] == null)
            {
                list=new List<Ingredient>();
            }

            else
            {
                list=(List<Ingredient>)Session["mycart"]; }

                list.Add(db.Ingredients.Where(p => p.ingredient_id==id).FirstOrDefault());
            list[list.Count-1].pro_quant=1;
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
        

        public ActionResult minus(int rowno)
        {
            List<Ingredient> list = (List<Ingredient>)Session["mycart"];

            list[rowno].pro_quant--;
            if (list[rowno].pro_quant<1)
            {
                list.RemoveAt(rowno);

            }
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
        public ActionResult plus(int rowno)
        {
            List<Ingredient> list = (List<Ingredient>)Session["mycart"];
            list[rowno].pro_quant++;
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
        public ActionResult remove(int rowno)
        {
            List<Ingredient> list = (List<Ingredient>)Session["mycart"];
            list.RemoveAt(rowno);
            Session["mycart"]= list;
            return RedirectToAction("cart");
        }
       
        
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult parchasenow(Order o)
        {
            o.Order_date=System.DateTime.Now;
            o.Order_type="Purchase"; 
            o.Order_status="Paid";


              
        

            Session["order"]=o;
            return RedirectToAction("orderbooked");
        }

        public ActionResult orderbooked()

        {
            Order o = (Order)Session["order"];


            /* //Define email parameters
            string senderEmail = "fizzamunawar227@gmail.com";
            string recipientEmail = o.Order_Email;
            string subject = "Order Confirmation";
            string body = " <b>Hunger & Spice !</b> </br> Thanks for your order";

            //// Create a MailMessage object
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

            //// Create a SmtpClient object
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            //// Set the SMTP client properties
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("fizzamunawar227@gmail.com", "gcliobddrvgwtjvo");

            //// Send the email
            smtpClient.Send(mailMessage);
            */


            Order order = db.Orders.Add(o);
            db.SaveChanges();

            List<Ingredient> P = (List<Ingredient>)Session["mycart"];
            for (int i = 0; i<P.Count; i++)
            {


                Orderdetail od = new Orderdetail();
                int OrderID = db.Orders.Max(u => u.Order_ID);
                od.Order_Fid=OrderID;
                od.ingredients_fid=P[i].ingredient_id;
                od.Quantity=P[i].pro_quant;
                od.price=P[i].ingredient_price;

                db.Orderdetails.Add(od);
                db.SaveChanges();
            }









            return View();
        }






    }
}
