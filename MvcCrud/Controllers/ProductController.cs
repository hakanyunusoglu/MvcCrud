using MvcCrud.Models;
using MvcCrud.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        ProductModel p = new ProductModel();
        public ActionResult Liste(string name)
        {
            if (name == null)
            {
                name = "";
            }
            p.pList = db.Products.Where(x => x.ProductName.Contains(name)).Select(x => new ProductsDto {
            CategoryName= x.Categories.CategoryName,
            CompanyName = x.Suppliers.CompanyName,
            ProductID = x.ProductID,
            ProductName = x.ProductName,
             Discontunied = x.Discontinued,
             UnitPrice = (decimal)x.UnitPrice}).ToList();
            return View(p);
        }
        public ActionResult Detay(int id)
        {
            p.Products = db.Products.Find(id);
            return View(p);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            p.Products = db.Products.Find(id);
            return View(p);

        }
        [HttpPost]
        public ActionResult Guncelle(int id, ProductModel pm)
        {
            if (ModelState.IsValid)
            {
                Products SecProduct = db.Products.Find(id);
                SecProduct.ProductID = pm.Products.ProductID;
                SecProduct.ProductName = pm.Products.ProductName;
                SecProduct.Categories.CategoryName = pm.Products.Categories.CategoryName;
                SecProduct.Suppliers.CompanyName = pm.Products.Suppliers.CompanyName;
                SecProduct.UnitPrice =(decimal) pm.Products.UnitPrice;
                SecProduct.Discontinued = pm.Products.Discontinued;
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
            p.Products = db.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Sil(int id, bool deger = true)
        {
            Products c = db.Products.Find(id);
            db.Products.Remove(c);
            db.SaveChanges();

            return RedirectToAction("Liste");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(ProductModel pm)
        {
            db.Entry(pm.Products).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}