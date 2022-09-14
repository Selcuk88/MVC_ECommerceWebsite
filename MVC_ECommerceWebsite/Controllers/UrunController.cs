using MVC_ECommerceWebsite.Models.Siniflar;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace MVC_ECommerceWebsite.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Urunler.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in context.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.Deger1=deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            context.Urunler.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = context.Urunler.Find(id);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            var urunDeger=context.Urunler.Find(id);
            return View("UrunGetir",urunDeger);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = context.Urunler.Find(urun.Urunid);
            urn.AlisFiyat = urun.AlisFiyat;
            urn.Durum = urun.Durum;
            urn.KategoriID = urun.KategoriID;
            urn.Marka = urun.Marka;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Stok = urun.Stok;
            urn.UrunAd = urun.UrunAd;
            urn.UrunGorsel=urun.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}