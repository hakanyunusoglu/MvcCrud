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
        public ActionResult Guncelle(int id)
        {
            model.categories = db.Categories.Find(id);
            return View(model);

        }
        public ActionResult Sil(int id)
        {
            var urun = db.Categories.Find(id);
            db.Categories.Remove(urun);


            return View();
        }
    }
}