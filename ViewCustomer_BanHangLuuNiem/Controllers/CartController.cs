using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewCustomer_BanHangLuuNiem.Models;

namespace ViewCustomer_BanHangLuuNiem.Controllers
{
    public class CartController : Controller
    {
        QuaLuuNiemEntities8 ctx = new QuaLuuNiemEntities8();
        // GET: Cart

        // GET: Cart
        public ActionResult Cart()
        {
           
            ViewBag.yourSessionId = HttpContext.Session.SessionID;  
            
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }


            // cal total of your cart

            float total = 0;

            foreach (ItemCart it in cart)
            {

                total += it.LineTotal;
            }

            ViewBag.Total = total;
            //passing to View
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {


            //step 1
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }



            int MaSP = Convert.ToInt32(Request.Form["MaSP"]);

            //ItemCart 
            SanPham sp = ctx.SanPhams.Where(t => t.MaSP == MaSP).SingleOrDefault();
            int qty = Convert.ToInt32(Request.Form["txtQuantity"]);

            ItemCart item = new ItemCart()
            {

                SanPham = sp,
                Quantity = qty,
                LineTotal = (float)(qty * sp.GiaBan)

            };
            //step 2
            cart.Add(item);
            //step 3

            HttpContext.Session["yourcart"] = cart;



            return RedirectToAction("Cart");
        }
   

        public ActionResult Checkout(int id = 0)
        {
            KhachHang userModel = new KhachHang();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Checkout(KhachHang userModel)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            using (QuaLuuNiemEntities8 dbModel = new QuaLuuNiemEntities8())
            {
                if (dbModel.KhachHangs.Any(x => x.TenKH == userModel.TenKH))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Register", userModel);
                }
                dbModel.KhachHangs.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registraction Successfull";
            return RedirectToAction("Index", "Home", new KhachHang());
        }
    }
}