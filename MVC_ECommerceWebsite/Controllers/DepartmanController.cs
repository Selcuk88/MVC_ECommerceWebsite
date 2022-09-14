using MVC_ECommerceWebsite.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ECommerceWebsite.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context context = new Context();
        public ActionResult Index()
        {
            var departmanlar = context.Departmanlar.Where(d => d.Durum == true).ToList();
            return View(departmanlar);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman dprt)
        {
            context.Departmanlar.Add(dprt);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dprt = context.Departmanlar.Find(id);
            dprt.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dprt = context.Departmanlar.Find(id);
            return View("DepartmanGetir", dprt);
        }
        public ActionResult DepartmanGuncelle(Departman dprt)
        {
            var dep = context.Departmanlar.Find(dprt.Departmanid);
            dep.DepartmanAd = dprt.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }        
        public ActionResult DepartmanDetay(int id)
        {
            ViewBag.dprt = context.Departmanlar.Where(d => d.Departmanid == id).Select(d => d.DepartmanAd).FirstOrDefault();
            var personeller = context.Personeller.Where(p => p.Departmanid == id).ToList();
            return View(personeller);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            Personel pers = context.Personeller.Find(id);
            ViewBag.personelAd = pers.PersonelAd + " " + pers.PersonelSoyad;
            var satislar = context.SatisHareketler.Where(s => s.Personelid == id).ToList();
            return View(satislar);
        }
    }
}