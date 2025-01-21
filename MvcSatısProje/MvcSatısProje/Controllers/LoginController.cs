using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;
using System.Web.Security;

namespace MvcSatısProje.Controllers
{
    public class LoginController : Controller
    {
        DbMvcStokEntities1 db=new DbMvcStokEntities1();
        
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBLADMİN t)
        {
            var bilgiler=db.TBLADMİN.FirstOrDefault(x=>x.kullanici==t.kullanici && x.sifre==t.sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici,false);
                return RedirectToAction("MusteriList", "Musteri");
            }
            else
            {
                return View(t);
            }
        }
    }
}