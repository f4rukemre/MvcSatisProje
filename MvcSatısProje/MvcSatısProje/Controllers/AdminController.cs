using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;

namespace MvcSatısProje.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcStokEntities1 db=new DbMvcStokEntities1();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMİN admin)
        {
            db.TBLADMİN.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}