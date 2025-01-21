using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSatısProje.Models;

namespace MvcSatısProje.Controllers
{
    public class KategoriController : Controller
    {
        DbMvcStokEntities1 db=new DbMvcStokEntities1();
        public ActionResult CategoryList()
        {
            var category=db.TBLKATEGORILER.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TBLKATEGORILER category)
        {
            db.TBLKATEGORILER.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category=db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = db.TBLKATEGORILER.Find(id);
            return View(category);
        }
        public ActionResult UpdateCategory(TBLKATEGORILER category)
        {
            var updatedCategory=db.TBLKATEGORILER.Find(category.ID);
            updatedCategory.AD=category.AD;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}