using System.Linq;
using System.Web.Mvc;
using MvcOkulYS.Models.EntityFramework;

namespace MvcOkulYS.Controllers
{
    public class KuluplerController : Controller
    {

        dbMvcOkulEntities db = new dbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.TBL_KULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBL_KULUPLER p2)
        {
            db.TBL_KULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        { // Uyarı gösterme özelliği eklenecek.
            var kulup = db.TBL_KULUPLER.Find(id);
            db.TBL_KULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBL_KULUPLER.Find(id);
            return View("KulupGetir",kulup);
        }
        public ActionResult Guncelle(TBL_KULUPLER p)
        {
            var klp = db.TBL_KULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            klp.KULUPKONTENJAN = p.KULUPKONTENJAN;
            db.SaveChanges();
            return RedirectToAction("Index","Kulupler");
        }
    }
}