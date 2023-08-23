using appweb.help;
using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace appweb.Controllers
{
    public class tkNguoiDungController : Controller
    {
        // GET: tkNguoiDung
        checkGmail check1=new checkGmail();
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(string Gmail,string tenDN,string Password, string RefestPassword) {
            qlBhEntities db=new qlBhEntities();
            var check = db.tkNguoiDung.Where(x => x.tenDN == tenDN || x.Gmail == Gmail);
            ViewBag.tk =tenDN;
            if (check.Count() == 1)
            {
                TempData["error"] = "tk da ton tai";
                return View();
            }
            else
            {
                if (check1.ktra(Gmail) == true)
                {
                    tkNguoiDung a = new tkNguoiDung();
                    if (Password == RefestPassword)
                    {
                        Session.Add("user", tenDN);
                        a.PassSalt = maHoaSHA.GenerateSalt();
                        a.tenDN = tenDN;
                        a.Gmail = Gmail;
                        a.PassHash = maHoaSHA.maHoa(Password, a.PassSalt, maHoaSHA.peper());
                        db.tkNguoiDung.Add(a);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["pass"] = "Mật khẩu nhập lại không trùng với mật khẩu đã nhập";
                        return View();
                    }
                    
                }
                else
                {
                    TempData["checkemail"] = "Gmail nhập không đúng kiểu";
                    if (Password != RefestPassword)
                    {
                        TempData["pass"] = "Mật khẩu nhập lại không trùng với mật khẩu đã nhập";
                        return View();
                    }
                    return View();
                }


            }
            
        }
        public ActionResult DangNhap() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string user, string password)
        {
            
            qlBhEntities db = new qlBhEntities();
           tkNguoiDung a=db.tkNguoiDung.Where(m=>m.tenDN== user).FirstOrDefault();
            if (a != null)
            {
                var x = maHoaSHA.maHoa(password, a.PassSalt, maHoaSHA.peper());
                if(x ==a.PassHash) {
                    Session["user"] = user;
                    Session["gmail"] = a.Gmail;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Tài Khoản Mật Khẩu Không Đúng";
                    return View();
                }
            }
            else
            {

                TempData["error"] = "Tài Khoản Mật Khẩu Không Đúng";
                return View();
            }
        }
        public ActionResult dangXuat() {

            Session.Remove("user");
            Session.Remove("gmail");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
    }
}