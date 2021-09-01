using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;
namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAİL == p.MAİL &&
            x.SIFRE == p.SIFRE);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAİL, false);
                Session["Mail"] = bilgiler.MAİL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
           else
            {
                return View();
            }
        }
    }
}