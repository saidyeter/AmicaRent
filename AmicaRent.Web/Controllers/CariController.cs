using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataAccess;

namespace WebApplication.Controllers
{
    public class CariController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: Cari
        public ActionResult Index()
        {
            return View(db.viewCari.ToList());
        }

        // GET: Cari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cari = db.viewCari.SingleOrDefault(x => x.Cari_ID == id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // GET: Cari/Create
        public ActionResult Create()
        {

            List<CariUyruk> uyrukList = db.CariUyruk.ToList();
            ViewBag.UyrukList = uyrukList;
            List<CariSehir> sehirList = db.CariSehir.ToList();
            ViewBag.SehirList = sehirList;

            Dictionary<int, string> cinsiyet = new Dictionary<int, string>();
            cinsiyet.Add(1, "Erkek");
            cinsiyet.Add(2, "Kadın");
            ViewBag.Cinsiyet = cinsiyet;
            return View();
        }

        // POST: Cari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cari_ID,Cari_AdSoyad,Cari_UyrukID,Cari_IDNumber,Cari_Cinsiyet,Cari_DogumTarihi,Cari_EpostaAdresi,Cari_Adres1,Cari_Adres2,CariSehir_ID,Cari_MobilTelefon,Cari_LokalTelefon,Cari_CreateDate")] Cari cari)
        {
            if (ModelState.IsValid)
            {
                cari.Cari_CreateDate = DateTime.Now;
                db.Cari.Add(cari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cari);
        }

        // GET: Cari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Cari.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // POST: Cari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cari_ID,Cari_AdSoyad,Cari_UyrukID,Cari_IDNumber,Cari_Cinsiyet,Cari_DogumTarihi,Cari_EpostaAdresi,Cari_Adres1,Cari_Adres2,CariSehir_ID,Cari_MobilTelefon,Cari_LokalTelefon,Cari_CreateDate")] Cari cari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cari);
        }

        // GET: Cari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Cari.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // POST: Cari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cari cari = db.Cari.Find(id);
            db.Cari.Remove(cari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
