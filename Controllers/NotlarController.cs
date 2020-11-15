using System.Linq;
using System.Web.Mvc;
using MvcOkulYS.Models;
using System.Collections.Generic;
using MvcOkulYS.Models.EntityFramework;

namespace MvcOkulYS.Controllers
{
    public class NotlarController : Controller
    {
        dbMvcOkulEntities db = new dbMvcOkulEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var SinavNotlar = db.TBL_NOTLAR.ToList();            
            return View(SinavNotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            List<SelectListItem> values = (from i in db.TBL_OGRENCILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.OGRAD + " " + i.OGRSOYAD,
                                               Value = i.OGRID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            List<SelectListItem> values2 = (from i in db.TBL_DERSLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DERSAD,
                                               Value = i.DERSID.ToString()
                                           }).ToList();
            ViewBag.vl2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBL_NOTLAR tbn)
        {
            var ogr = db.TBL_OGRENCILER.Where(m => m.OGRID == tbn.TBL_OGRENCILER.OGRID).FirstOrDefault();
            tbn.TBL_OGRENCILER = ogr;
            var drs = db.TBL_DERSLER.Where(m => m.DERSID == tbn.TBL_DERSLER.DERSID).FirstOrDefault();
            tbn.TBL_DERSLER = drs;
            db.TBL_NOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TBL_NOTLAR.Find(id);            
            return View("NotGetir", notlar);
        }

        public int ortalama;
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBL_NOTLAR p, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            if (model.islem == "HESAPLA")
            {
                //işlem1
                ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
                var snv = db.TBL_NOTLAR.Find(p.NOTID);
                if (ortalama >= 50)
                {
                    snv.DURUM = true;
                    ViewBag.drm = snv.DURUM.ToString();
                }
                if (ortalama < 50)
                {
                    snv.DURUM = false;
                    ViewBag.drm = snv.DURUM.ToString();
                }
            }
            if (model.islem == "NOTGUNCELLE")
            {
                //işlem2
                var snv = db.TBL_NOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                snv.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index","Notlar");
            }            
            return View();
        }
    }
}