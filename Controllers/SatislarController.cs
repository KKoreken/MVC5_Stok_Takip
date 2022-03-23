using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Uygulama.Models.Entity;

namespace Stok_Uygulama.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokUygulamaEntities db = new DbMvcStokUygulamaEntities();
        public ActionResult Index()
        {
            var satislar = db.TBLSatis.ToList();
            return View("Index",satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {   //Ürün Listeleme
            List<SelectListItem> item = (from i in db.TBLUrunler.ToList() select new SelectListItem { Text = i.ad, Value = i.id.ToString() }).ToList();
            ViewBag.deger = item;

            //Personel Listeleme
            List<SelectListItem> item2 = (from i in db.TBLPersonel.ToList() select new SelectListItem { Text = i.ad+" " + i.soyad, Value = i.id.ToString() }).ToList();
            ViewBag.deger2 = item2;


            //Müşteri Listeleme
            List<SelectListItem> item3 = (from i in db.TBLMusteri.ToList() select new SelectListItem { Text = i.ad +" "+ i.soyad, Value = i.id.ToString() }).ToList();
            ViewBag.deger3 = item3;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSatis item)
        {
            var urun = db.TBLUrunler.Where(x => x.id == item.TBLUrunler.id).FirstOrDefault();
            var musteri = db.TBLMusteri.Where(x => x.id == item.TBLMusteri.id).FirstOrDefault();
            var personel = db.TBLPersonel.Where(x => x.id == item.TBLPersonel.id).FirstOrDefault();
            item.TBLUrunler = urun;
            item.TBLMusteri = musteri;
            item.TBLPersonel = personel;
            item.tarih = DateTime.Parse(DateTime.Now.ToString());
            db.TBLSatis.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}