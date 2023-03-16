using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewCustomer_BanHangLuuNiem.Models;
namespace ViewCustomer_BanHangLuuNiem.Controllers
{
    public class AddToCartController : Controller
    {
        QuaLuuNiemEntities8 ctx = new QuaLuuNiemEntities8();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart ==null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // GET: AddToCart
        //add item to cart
        public ActionResult AddToCart(int MaSP)
        {
            var sp = ctx.SanPhams.SingleOrDefault(s => s.MaSP == MaSP);
                if (sp != null) 
                {
                    GetCart().Add(sp);
                }
            return RedirectToAction("ShowToCart", "AddToCart");
        }
        //page cart 
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            
                return RedirectToAction("ShowToCart", "AddToCart");
                Cart cart = Session["Cart"] as Cart;
                return View(cart);
            
        }

        public ActionResult UpdateQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int MaSP =int.Parse( form["ID_SP"]);
            int quantity = int.Parse(form["quantity"]);
            cart.UpdateQuantity(MaSP, quantity);
            return RedirectToAction("ShowToCart", "AddToCart");
        }

        public ActionResult RemoveItem(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "AddToCart");       
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart !=null)
            
                total_item = (int) cart.Total_Quantity();
                ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");
        }

        //checkout
       
    }
}