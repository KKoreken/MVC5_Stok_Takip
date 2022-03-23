using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Uygulama.Models.Entity;

namespace Stok_Uygulama.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokUygulamaEntities db = new DbMvcStokUygulamaEntities();
        public ActionResult Index(string item)
        {
            //var urunler = db.TBLUrunler.Where(x => x.durum == true).ToList(); 
            var urunler = from x in db.TBLUrunler select x;
            if (!string.IsNullOrEmpty(item))
            {
                urunler = urunler.Where(x => x.ad.Contains(item) && x.durum == true);
            }
            return View(urunler.ToList());
        }   
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> item = (from i in db.TBLKategori.ToList() select new SelectListItem {Text= i.ad,Value=i.id.ToString()}).ToList();
            ViewBag.deger = item;
            return View();

        }



        [HttpPost]
        public ActionResult YeniUrun(TBLUrunler item)
        {
            var kategori = db.TBLKategori.Where(x => x.id == item.TBLKategori.id).FirstOrDefault();
            item.TBLKategori = kategori;
            item.durum = true;
            db.TBLUrunler.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir (int id)
        {
            List<SelectListItem> urun = (from x in db.TBLKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.urunkategori = urun;
            var item = db.TBLUrunler.Find(id);
            return View("UrunGetir", item);
        }
        public ActionResult UrunGuncelle(TBLUrunler item)
        {
            var urun = db.TBLUrunler.Find(item.id);
            urun.ad = item.ad;
            urun.marka = item.marka;
            urun.stok = item.stok;
            urun.alisFiyati = item.alisFiyati;
            urun.satifFiyati = item.satifFiyati;
            var ktg = db.TBLKategori.Where(x => x.id == item.TBLKategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(TBLUrunler item)
        {
            var urun = db.TBLUrunler.Find(item.id);
            urun.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}