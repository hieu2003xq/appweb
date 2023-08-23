using appweb.help;
using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appweb.Controllers
{
    public class chiTietSPController : Controller
    {
        // GET: chiTietSP
        qlBhEntities db = new qlBhEntities();
        cart b=new cart();
        see see1 = new see();
        [HttpGet]
        public ActionResult Index(int Id)
        {
            if (Session["gmail"] == null)
            {


                ViewBag.tongSL = b.tongSL();

            }
            else
            {
                ViewBag.tongSL = b.tongSL(Session["gmail"].ToString());
            }
            see1.dssp=db.sanPham.ToList();
            see1.sp1 = db.newpro.Where(m => m.maSP == Id).FirstOrDefault();
            return View(see1);
        }
        [HttpGet]
        public ActionResult shopSP(int Id) {
            if (Session["gmail"] == null)
            {


                ViewBag.tongSL = b.tongSL();

            }
            else
            {
                ViewBag.tongSL = b.tongSL(Session["gmail"].ToString());
            }
            see1.dssp = db.sanPham.ToList();
            see1.sp2 = db.sanPham.Where(m=>m.maSP==Id).FirstOrDefault();
            return View(see1);
        }
    }
}