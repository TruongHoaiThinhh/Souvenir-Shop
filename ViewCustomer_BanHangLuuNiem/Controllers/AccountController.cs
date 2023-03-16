using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewCustomer_BanHangLuuNiem.Models;
using System.Data;
using System.Data.Sql;

namespace ViewCustomer_BanHangLuuNiem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
     
        public ActionResult Register(int id = 0)
        {
            AccountUser userModel = new AccountUser();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(AccountUser userModel)
        {
            using (QuaLuuNiemEntities8 dbModel = new QuaLuuNiemEntities8())
            {
                if (dbModel.AccountUsers.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Register", userModel);
                }
                dbModel.AccountUsers.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registraction Successfull";
            return RedirectToAction("Index", "Home", new AccountUser());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(ViewCustomer_BanHangLuuNiem.Models.AccountUser userModel)
        {
            using (QuaLuuNiemEntities8 db = new QuaLuuNiemEntities8())
            {
                var userDetails = db.AccountUsers.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Login", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.Username;
                    return RedirectToAction("Index", "Home" );
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }
}