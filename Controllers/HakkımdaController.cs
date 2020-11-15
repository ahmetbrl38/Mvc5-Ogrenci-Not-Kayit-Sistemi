using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulYS.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}