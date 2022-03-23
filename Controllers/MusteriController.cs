using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Uygulama.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Stok_Uygulama.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri     
        DbMvcStokUygulamaEntities db = new DbMvcStokUygulamaEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var musteriler = db.TBLMusteri.ToList();
            var musteriler = db.TBLMusteri.Where(x=> x.durum==true).ToList().ToPagedList(sayfa, 10);
            return View(musteriler);
        }

        [HttpGet]

        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult YeniMusteri(TBLMusteri item ){
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            else
            {
                item.durum = true;
                db.TBLMusteri.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

        }

        public ActionResult MusteriSil(TBLMusteri item)
        {
            var musteribul = db.TBLMusteri.Find(item.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var item = db.TBLMusteri.Find(id);
            return View("MusteriGetir",item);
        }
        public ActionResult MusteriGuncelle(TBLMusteri item )
        {
            var i = db.TBLMusteri.Find(item.id);
            i.ad = item.ad;
            i.soyad = item.soyad;
            i.sehir = item.sehir;
            i.bakiye = item.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}