using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appweb.Areas.Admin.Controllers
{
    public class DanhSachCacDonController : Controller
    {
        // GET: Admin/DanhSachCacDon
        public ActionResult Index()
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db=new qlBhEntities();
                List<donHang>a=db.donHang.ToList(); 
                return View(a);
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
           
        }
        public ActionResult Donrieng()
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                List<DonHangRieng> a = db.DonHangRieng.ToList();
                return View(a);
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
        }
        [HttpGet]
        public ActionResult DonTheoTen(string Gmail)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                List<donHang> a = db.donHang.Where(m=>m.Gmail==Gmail).ToList();
                return View(a);
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
        }
    }
    }
