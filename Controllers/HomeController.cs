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
        public ActionResult Indexcustomer(int? id)
        {
            Menu m = new Menu();
            /* menu is a model have to  list cat or pro */
            m.cat= db.Categories.ToList();
            var orders = db.Orderdetails.GroupBy(od => od.Product_fid)
                             .Where(g => g.Count() >= 5)
                             .Select(g => g.Key)
                             .ToList();

            if (id == null)
            {
                m.pro = db.products.Where(p =>orders.Contains(p.Products_id)).ToList();
            }
            else
            {
                m.pro = db.products.Where(p => p.category_fid == id && orders.Contains(p.Products_id))
                                   .ToList();
            }

            return View(m);
          
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
        public ActionResult login(admin A)
        {
          
            admin a = db.admins.Where(x => x.Admin_email==A.Admin_email && x.Admin_password==A.Admin_password).FirstOrDefault();
            if (a !=null)
            {
                Session["admin"]=a;
                return RedirectToAction("indexadmin", "Home");
            }
            else
            {
                ViewBag.message="Invalid Email or password";
                return View();
            }

        }
        public ActionResult logout()
        {
            Session["admin"]= null;
                  return RedirectToAction("login"); }



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
            Boolean isexist = false;
            foreach (var item in list)
            {
                if (id==item.Products_id)
                {
                    isexist =true;
                    item.pro_quan++;
                }
            }
            if (isexist==false)
            {


                list.Add(db.products.Where(p => p.Products_id==id).FirstOrDefault());
                list[list.Count-1].pro_quan=1;
            }
              
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
            if (Session["customer"] !=null)
            {
                customer c = (customer)Session["customer"];
                o.Customer_fid=c.Customer_id;
            }

            o.Order_type="Sale";

            Session["order"]=o;
            if (o.Order_status=="COD")
            {
                return RedirectToAction("orderbooked");

            }
            else

            {
                   return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=huda.basharat41@gmail.com&item_name= hungernspiceitems&return=https://localhost:44331/Home/orderbooked&amount=" + double.Parse(Session["Totalamount"].ToString()) / 286);
            }
        }

        public ActionResult orderbooked()

        { Order o = (Order)Session["order"];

            //+MailProvider.SentfromMail(BaseHelper.Customer.CUSTOMER_EMAIL, "Order Confirmation", "Your Order has been booked and will be delivered within a day, Regards Hunger & spice <br /> Thanks");

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
        public ActionResult closeorder()
        {
            Session["Order"]= null;
            Session["mycart"]= null;
            Session["Totalamount"]=null;

            return RedirectToAction("indexcustomer");
        }







    }
}
