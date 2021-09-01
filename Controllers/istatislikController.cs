using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatislikController : Controller
    {
        // GET: istatislik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKİTAP.Count();
            var deger3 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x =>x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;

            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"),
                    Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
                return RedirectToAction("Galeri");

            }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKİTAP.Count();
            var deger2 = db.TBLUYELER.Count();
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger5 = db.TBLKATEGORİ.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TBLKİTAP.GroupBy(x => x.YAYINEVİ).OrderByDescending(z => z.Count()).Select(y =>
                new { y.Key }).FirstOrDefault();
            var deger10 = db.TBLHAREKET.Where(x => x.ALISTARIH == DateTime.Today).Select(c => c.KITAP).Count();
            var deger11 = db.TBLILETISIM.Count();
            var deger12 = db.enaktifUye().FirstOrDefault();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;



            return View();
        }
        }
    }