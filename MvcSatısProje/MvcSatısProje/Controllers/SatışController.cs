using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;

namespace MvcSatısProje.Controllers
{
    public class SatışController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult SatısList()
        {
            var satislar = db.TBLSATISLAR.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult CreateList()
        {
            //Ürünler
            List<SelectListItem> urun = (from x in db.TBLURUNLER.Where(x => x.DURUM == true).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD,
                                             Value = x.ID.ToString(),
                                         }).ToList();
            //Personeller
            List<SelectListItem> personel = (from x in db.TBLPERSONEL.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD + " " + x.SOYAD,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            //Müşteriler
            List<SelectListItem> musteri = (from x in db.TBLMUSTERILER.Where(x => x.DURUM == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AD + " " + x.SOYAD,
                                                Value = x.ID.ToString(),
                                            }).ToList();
            ViewBag.a = urun;
            ViewBag.b = personel;
            ViewBag.c = musteri;
            return View();
        }
        [HttpPost]
        public ActionResult CreateList(TBLSATISLAR satislar)
        {
            var urun = db.TBLURUNLER.Where(x => x.ID == satislar.TBLURUNLER.ID).FirstOrDefault();
            var musteri = db.TBLMUSTERILER.Where(x => x.ID == satislar.TBLMUSTERILER.ID).FirstOrDefault();
            var personel = db.TBLPERSONEL.Where(x => x.ID == satislar.TBLPERSONEL.ID).FirstOrDefault();
            satislar.TBLURUNLER = urun;
            satislar.TBLMUSTERILER = musteri;
            satislar.TBLPERSONEL = personel;
            satislar.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLSATISLAR.Add(satislar);
            db.SaveChanges();
            return RedirectToAction ("SatısList");
        }
    }
}