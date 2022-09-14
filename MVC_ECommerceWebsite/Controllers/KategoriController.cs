using MVC_ECommerceWebsite.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;

namespace MVC_ECommerceWebsite.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();
        public ActionResult Index()
        {
            var kategoriler = context.Kategoriler.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoriler.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoriler.Find(id);
            context.Kategoriler.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = context.Kategoriler.Find(kategori.KategoriID);
            ktgr.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}