using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]

    public class KayıtOlController : Controller
    {
        // GET: KayıtOl

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayıt(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayıt");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();



        }

    }
}