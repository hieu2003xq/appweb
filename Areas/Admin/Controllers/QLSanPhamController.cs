using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using System.Drawing.Printing;
using System.Data.Entity.Infrastructure;
using System.Data;
using appweb.Areas.Admin.HELPER;
using Microsoft.Security.Application;

namespace appweb.Areas.Admin.Controllers
{
    public class QLSanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult DanhSachSP(int? page, int? pageSize)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                List<sanPham> dsSP = db.sanPham.ToList();
                if (page == null) page = 1;
                if (pageSize == null) pageSize = 3;
                ViewBag.pageSize = pageSize;

                return View(dsSP.ToPagedList((int)page, (int)pageSize));
            }
            else {
                return RedirectToAction("DangNhap", "HomeAdmin");
            }

        }
        public ActionResult ThemMoiSP()
        {
            if (Session["AD"] != null)
            {


                return View();
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemMoiSP(sanPham model)
        {

            if (Session["AD"] != null)
            {
               var a= Sanitizer.GetSafeHtmlFragment(model.tenSP);
                qlBhEntities db = new qlBhEntities();
                if (!string.IsNullOrEmpty(a)) { 
                foreach (var s in db.sanPham)
                {
                    if (s.maSP == model.maSP)
                    {
                        ModelState.AddModelError("", " Mã Sản Phẩm Đã Tồn Tại Vui lòng nhập lại");
                        return View(model);
                    }
                    else
                    {
                        if (model.giaBan > 0)
                        {
                            db.sanPham.Add(model);


                        }
                        else
                        {
                            ModelState.AddModelError("", "Giá Phải Lớn Hơn 0");
                            return View(model);
                        }
                    }
                }
                db.SaveChanges();
                    return RedirectToAction("DanhSachSP", "QLSanPham");
                }
                else
                {
                    TempData["antiXSS"] = "không được nhập script";
                    return View(model);
                }
               
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }

        }
        [HttpGet]
        public ActionResult Sua(int id)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                sanPham model1 = db.sanPham.Find(id);
                return View(model1);
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Sua(sanPham model) {
            if (Session["AD"] != null)
            {
                var a = Sanitizer.GetSafeHtmlFragment(model.tenSP);
                qlBhEntities db = new qlBhEntities();
                if (!string.IsNullOrEmpty(a)) { 
                var sua = db.sanPham.Find(model.maSP);
                if (model.giaBan > 0)
                {
                    sua.tenSP = model.tenSP;
                    sua.hinhAnh = model.hinhAnh;
                    sua.giaBan = model.giaBan;

                    db.SaveChanges();
                    return RedirectToAction("DanhSachSP");
                }
                else
                {
                    ModelState.AddModelError("", "Giá Phải Lớn Hơn 0");
                    return View(model);
                }
                }
                else {
                    TempData["antiXSS"] = "không được nhập script";
                    return View(model); 
                }
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }


        }
        [HttpGet]
        public ActionResult xoa(int id)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                var xoa = db.sanPham.Find(id);
                db.sanPham.Remove(xoa);
                db.SaveChanges();
                return RedirectToAction("DanhSachSP");
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }
        }
        public ActionResult TimKiem(string ten)
        {
            if (Session["AD"] != null)
            {
                qlBhEntities db = new qlBhEntities();
                List<sanPham> sp = db.sanPham.Where(m => m.tenSP.ToLower().Contains(ten.ToLower()) == true).ToList();
                if (sp.Count > 0)
                {
                    return View(sp);
                }
                else
                {
                    ModelState.AddModelError("", "khong co san pham");
                    return RedirectToAction("DanhSachSP");
                }
            }
            else { return RedirectToAction("DangNhap", "HomeAdmin"); }

        }

        [HttpGet]
        public ActionResult GetList()
        {
            qlBhEntities db = new qlBhEntities();
            var a = db.sanPham.ToList();
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            int recordsTotals = a.Count;
            if (!string.IsNullOrEmpty(searchValue))
            {
                a=a.Where(m=>m.tenSP.ToLower().Contains(searchValue)).ToList();
            }
            int totalrowsafterfiltering = a.Count;

            a =a.Skip(start).Take(length).ToList();
            

            return Json(new { data = a, draw = Request["draw"],recordsTotals=recordsTotals, recordsFiltered= totalrowsafterfiltering },JsonRequestBehavior.AllowGet);
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult thu() {
            return View();
        }

        }
    

    } 
    


    
