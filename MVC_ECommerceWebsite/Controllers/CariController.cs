using MVC_ECommerceWebsite.Models.Siniflar;
using System.Linq;
using System.Web.Mvc;

namespace MVC_ECommerceWebsite.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();
        public ActionResult Index()
        {
            var cariler = context.Cariler.Where(c => c.Durum == true).ToList();
            return View(cariler);
        }
        [HttpGet]
        public ActionResult YeniCariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCariEkle(Cari cari)
        {
            cari.Durum = true;
            context.Cariler.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = context.Cariler.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = context.Cariler.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var _cari = context.Cariler.Find(cari.Cariid);
            _cari.CariAd = cari.CariAd;
            _cari.CariSoyad = cari.CariSoyad;
            _cari.CariSehir = cari.CariSehir;
            _cari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}