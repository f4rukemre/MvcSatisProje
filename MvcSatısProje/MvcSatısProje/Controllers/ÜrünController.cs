using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;

namespace MvcSatısProje.Controllers
{
    public class ÜrünController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult UrunList(string p)
        {
            //var urun = db.TBLURUNLER.Where(x=>x.DURUM==true).ToList();
            var urun = db.TBLURUNLER.Where(x => x.DURUM == true);
            if (!string.IsNullOrEmpty(p))
            {
                urun = urun.Where(x => x.AD.Contains(p) && x.DURUM == true);
            }
            return View(urun.ToList());
        }
        [HttpGet]
        public ActionResult CreateUrun()
        {
            List<SelectListItem> ktg = (from x in db.TBLKATEGORILER.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.ID.ToString(),
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUrun(TBLURUNLER urun)
        {
            urun.DURUM = true;
            var ktgr = db.TBLKATEGORILER.Where(x => x.ID == urun.TBLKATEGORILER.ID).FirstOrDefault();
            urun.TBLKATEGORILER = ktgr;
            db.TBLURUNLER.Add(urun);
            db.SaveChanges();
            return RedirectToAction("UrunList");
        }
        public ActionResult DeleteUrun(TBLURUNLER urun)
        {
            var urunbul = db.TBLURUNLER.Find(urun.ID);
            db.TBLURUNLER.Remove(urunbul);
            urunbul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("UrunList");
        }
        [HttpGet]
        public ActionResult UpdateUrun(int id)
        {
            var urunler = db.TBLURUNLER.Find(id);
            var kategoriler = db.TBLKATEGORILER.ToList();
            var list = new SelectList(kategoriler, "ID", "AD", urunler.TBLKATEGORILER.ID);
            ViewBag.Kategoriler = list;
            return View(urunler);
        }
        [HttpPost]
        public ActionResult UpdateUrun(TBLURUNLER urun)
        {
            var updatedUrun = db.TBLURUNLER.Find(urun.ID);
            updatedUrun.AD = urun.AD;
            updatedUrun.MARKA = urun.MARKA;
            updatedUrun.STOK = urun.STOK;
            updatedUrun.ALISFIYAT = urun.ALISFIYAT;
            updatedUrun.SATISFIYAT = urun.SATISFIYAT;
            updatedUrun.KATEGORI = urun.TBLKATEGORILER.ID;
            db.SaveChanges();
            return RedirectToAction("UrunList");
        }
    }
}