using appweb.help;
using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appweb.Controllers
{
    public class newProductController : Controller
    {
        // GET: newProduct
        cart b=new cart();
       
       
        public ActionResult Index()
        {
            if (Session["gmail"] == null)
            {


                ViewBag.tongSL = b.tongSL();

            }
            else
            {
                ViewBag.tongSL = b.tongSL(Session["gmail"].ToString());
            }
            qlBhEntities db=new qlBhEntities();
            List<newpro> newPro=db.newpro.ToList();
            return View(newPro);
        }
    }
}