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

            Boolean isexist = false;
            foreach (var item in list)
            {
                if (id==item.ingredient_id)
                {
                    isexist =true;
                    item.pro_quant++;
                }
            }
            if (isexist==false)
            {

                list.Add(db.Ingredients.Where(p => p.ingredient_id==id).FirstOrDefault());
                list[list.Count-1].pro_quant=1;
            }
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


        public ActionResult closeorder()
        {
            Session["Order"]= null;
            Session["mycart"]= null;
            return RedirectToAction("parchase");
        }
        


    }
}
