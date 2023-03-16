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
    public class HomeController : Controller
    {
        QuaLuuNiemEntities8 ctx = new QuaLuuNiemEntities8();
        public ActionResult Index()
        {
            // Tao danh sach san pham can co de goi ra giao dien view
            List<SanPham> sp = ctx.SanPhams.ToList();
            List<SanPham> top10sp = ctx.SanPhams.OrderBy(x => x.GiaBan).Take(10).ToList();
            ViewBag.top10sp = top10sp;
            return View(sp);
        }

        public ActionResult Details(int MaSP)
        {               
            SanPham sp = ctx.SanPhams.Where(t => t.MaSP == MaSP).SingleOrDefault();
            
            ChiTietSanPham MaCT = ctx.ChiTietSanPhams.Where(x => x.MaSP == MaSP).SingleOrDefault();
            
            //List<DanhGia> MaDG = ctx.DanhGias.Where(x => x.MaSP == MaSP).ToList();

            //List<HinhAnh> MaIMG = ctx.HinhAnhs.Where(x => x.MaSP == MaSP).ToList();
            //ViewBag.madg = MaDG;
            //ViewBag.maIMG = MaIMG;
            ViewBag.mact = MaCT;
            ViewBag.MaSP = MaSP;
            return View(sp);         
        }

        public ActionResult Categories()
        {
            List<SanPham> sp = ctx.SanPhams.ToList();
            
            return View(sp);
            
          
        }

        public ActionResult Save_Review(DanhGia sp)
        {
            //save to db
            ctx.DanhGias.Add(sp);
            ctx.SaveChanges();
            return RedirectToAction("Details");
        }
        public ActionResult Add_Reviewt()
        {
            DanhGia review = new DanhGia();
            // list category
            List<DanhGia> danhGias = ctx.DanhGias.ToList();
            ViewBag.danhGias = danhGias;

            List<SanPham> sp = ctx.SanPhams.ToList();
            ViewBag.sp = sp;

            return RedirectToAction("Details");
        }
    }
}