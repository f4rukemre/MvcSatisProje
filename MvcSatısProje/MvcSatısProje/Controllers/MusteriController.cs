using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcSatısProje.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities1 db=new DbMvcStokEntities1();
        [Authorize]
        public ActionResult MusteriList(int sayfa=1)
        {
            var musterıliste = db.TBLMUSTERILER.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa, 4);
            return View(musterıliste);
        }
        [HttpGet]
        public ActionResult CreateMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMusteri(TBLMUSTERILER musteri)
        {
            musteri.DURUM = true;
            db.TBLMUSTERILER.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriList");
        }
        public ActionResult DeleteMusteri(TBLMUSTERILER musteri)
        {
            var musterıbul=db.TBLMUSTERILER.Find(musteri.ID);
            musterıbul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("MusteriList");
        }
        [HttpGet]
        public ActionResult UpdateMusteri(int id)
        {
            var musteri=db.TBLMUSTERILER.Find(id);
            return View(musteri);
        }
        [HttpPost]
        public ActionResult UpdateMusteri(TBLMUSTERILER musteri)
        {
            var updatedMusteri = db.TBLMUSTERILER.Find(musteri.ID);
            updatedMusteri.AD=musteri.AD;
            updatedMusteri.SOYAD = musteri.SOYAD;
            updatedMusteri.SEHIR = musteri.SEHIR;
            updatedMusteri.BAKIYE = musteri.BAKIYE;
            db.SaveChanges();
            return RedirectToAction("MusteriList");
        }
    }
}