using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.Security;
using appweb.help;
using PagedList;

namespace appweb.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {

        qlBhEntities db=new qlBhEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index(int?page,int? pageSize)
        {
            
            List<sanPham> dsSP = db.sanPham.ToList();
            if (Session["AD"] != null)
            {
                if(page==null) page = 1;
                if (pageSize==null) pageSize = 5; 
                ViewBag.pageSize=pageSize;
                return View(dsSP.ToPagedList((int)page, (int)pageSize));

            }
            else
            {
                return RedirectToAction("DangNhap");
            }

        }
        public ActionResult DangNhap()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string user,string password)
        {
            
            qlBhEntities db = new qlBhEntities();
            var maHoa = maHoaMD5.ChuyenVao(password);
            var data = db.TkAdmin.Where(m=>m.tenDN==user && m.Pass==maHoa);
            if (data.Count()>0)
            {
                Session["AD"] = "admin";   
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài Khoản Mật Khẩu Không Đúng";
                 return View();
            };  
        }
        public ActionResult DangKy() {
            if (Session["AD"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("DangNhap");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(string user,string pass,string refestpass)
        {
            qlBhEntities db = new qlBhEntities();
            if (Session["AD"] != null)
            {
                var check = db.TkAdmin.Where(m => m.tenDN == user);
                if (check.Count() > 0)
                {
                    TempData["tkTonTai"] = "tài khoản đã tồn tại";
                    return View();
                }
                else
                {
                    if (pass == refestpass)
                    {
                        int i = 2;
                        var a = maHoaMD5.ChuyenVao(pass);
                        TkAdmin tkad = new TkAdmin();
                        tkad.id = i;
                        tkad.tenDN = user;
                        tkad.Pass = a;
                        Session["AD"] = user;
                        db.TkAdmin.Add(tkad);
                        db.SaveChanges();
                        i++;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["khongTrungPass"] = "Mật khẩu nhập không trùng nhau";
                        return View();
                    }
                }
            }
            else
            {
                return RedirectToAction("DangNhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
      
    }
   
}
    
