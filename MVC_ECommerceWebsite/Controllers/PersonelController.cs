using MVC_ECommerceWebsite.Models.Siniflar;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_ECommerceWebsite.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Models.Siniflar.Context context = new Models.Siniflar.Context();
        public ActionResult Index()
        {
            var personeller = context.Personeller.ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in context.Departmanlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personeller.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in context.Departmanlar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.Departmanid.ToString()
                                          }).ToList();
            ViewBag.Deger1 = deger;

            var personel = context.Personeller.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {          
            var prs=context.Personeller.Find(p.Personelid);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.Departmanid = p.Departmanid;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}