using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appweb.Areas.Admin.Controllers
{
    public class DSKHController : Controller
    {
        // GET: Admin/DSKH
        public ActionResult DanhSach()

        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                List<khachHang> danhsachKH = db.khachHang.ToList();
                return View(danhsachKH);
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }

        }
        public ActionResult ThemMoi()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(khachHang model)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                db.khachHang.Add(model);
                //
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
        }
       
    }
}