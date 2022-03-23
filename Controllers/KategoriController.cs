using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok_Uygulama.Models.Entity;

namespace Stok_Uygulama.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokUygulamaEntities db = new DbMvcStokUygulamaEntities();
        [HttpGet]
        public ActionResult KategoriEkle() {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKategori item)
        {   
            db.TBLKategori.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var kategoriler = db.TBLKategori.ToList();
            return View(kategoriler);
        }
        public ActionResult KatSil(int id)
        {
            var kategori = db.TBLKategori.Find(id);
            db.TBLKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("/Index?sil=1");
        }

        public ActionResult KategoriGetir(int id)
        {
            var item = db.TBLKategori.Find(id);
            return View("KategoriGetir", item);
        }
        public ActionResult KategoriGuncelle(TBLKategori item )
        {
            var kategori = db.TBLKategori.Find(item.id);
            kategori.ad = item.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}