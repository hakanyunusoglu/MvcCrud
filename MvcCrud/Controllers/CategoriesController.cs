using MvcCrud.Models;
using MvcCrud.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        NorthwindEntities db = new NorthwindEntities();
        CategoriesModel model = new CategoriesModel();
        public ActionResult Liste(string name)
        {
            if (name == null)
            {
                name = "";
            }
            //Catagorı tablaosunda sarta bakıcak, ıcersınde parametre olarak name varmı dıye bakıyor
            model.cList = db.Categories.Where(x => x.CategoryName.Contains(name)).ToList();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.categories = db.Categories.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            model.categories = db.Categories.Find(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Guncelle(int id, CategoriesModel cm)
        {
            if(ModelState.IsValid)
            {
                Categories SecCategory = db.Categories.Find(id);
                SecCategory.CategoryName = cm.categories.CategoryName;
                SecCategory.Description = cm.categories.Description;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            model.categories = db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sil(int id, bool deger=true)
        {
            Categories c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();

            return RedirectToAction("Liste");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle (CategoriesModel cm)
        {
            db.Entry(cm.categories).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}