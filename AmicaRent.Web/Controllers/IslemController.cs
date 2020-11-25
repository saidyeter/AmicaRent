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
    public class IslemController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: Islem
        public ActionResult Index()
        {
            return View(db.viewIslem.ToList());
        }

        // GET: Islem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var islem = db.viewIslem.SingleOrDefault(x => x.Islem_ID == id);

            if (islem == null)
            {
                return HttpNotFound();
            }
            return View(islem);
        }

        // GET: Islem/Create
        public ActionResult Create()
        {

            List<Cari> cariList = db.Cari.ToList();
            ViewBag.CariList = cariList;

            Dictionary<int, string> aracList = new Dictionary<int, string>();
            foreach (var arac in db.viewAracList.ToList())
            {
                aracList.Add(arac.Arac_ID, arac.AracGrup_Adi + " " + arac.AracMarka_Adi + " " + arac.AracModel_Adi + " " + arac.Arac_Yil);
            }
            ViewBag.AracList = aracList;

            Dictionary<int, string> islemTipi = new Dictionary<int, string>();
            islemTipi.Add(1, "Rezervasyon");
            islemTipi.Add(2, "Kiralama");
            ViewBag.IslemTipi = islemTipi;

            return View();
        }

        // POST: Islem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Islem_ID,Islem_Tipi,Cari_ID,Arac_ID,Islem_BaslangicTarihi,Islem_BitisTarihi,Islem_IlkKM,Islem_SonKM,Islem_YakitDurumu,Islem_TeslimatLokasyonID,Islem_IadeLokasyonID,Islem_GunlukUcret,Islem_GunlukKMSiniri,Islem_ToplamKiralamaUcreti,Islem_ToplamKMAsimUcreti,Islem_ToplamEkstraHizmetler,Islem_ToplamValeHizmetleri,Islem_ToplamDigerUcretler,Islem_IskontoOrani,Islem_TahsilEdilen,Islem_KalanBorc,Islem_Status,Islem_CreateDate")] Islem islem)
        {
            if (ModelState.IsValid)
            {
                db.Islem.Add(islem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(islem);
        }

        // GET: Islem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }


            List<Cari> cariList = db.Cari.ToList();
            ViewBag.CariList = cariList;

            Dictionary<int, string> aracList = new Dictionary<int, string>();
            foreach (var arac in db.viewAracList.ToList())
            {
                aracList.Add(arac.Arac_ID, arac.AracGrup_Adi + " " + arac.AracMarka_Adi + " " + arac.AracModel_Adi + " " + arac.Arac_Yil);
            }
            ViewBag.AracList = aracList;

            Dictionary<int, string> islemTipi = new Dictionary<int, string>();
            islemTipi.Add(1, "Rezervasyon");
            islemTipi.Add(2, "Kiralama");
            ViewBag.IslemTipi = islemTipi;

            return View(islem);
        }

        // POST: Islem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Islem_ID,Islem_Tipi,Cari_ID,Arac_ID,Islem_BaslangicTarihi,Islem_BitisTarihi,Islem_IlkKM,Islem_SonKM,Islem_YakitDurumu,Islem_TeslimatLokasyonID,Islem_IadeLokasyonID,Islem_GunlukUcret,Islem_GunlukKMSiniri,Islem_ToplamKiralamaUcreti,Islem_ToplamKMAsimUcreti,Islem_ToplamEkstraHizmetler,Islem_ToplamValeHizmetleri,Islem_ToplamDigerUcretler,Islem_IskontoOrani,Islem_TahsilEdilen,Islem_KalanBorc,Islem_Status,Islem_CreateDate")] Islem islem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(islem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(islem);
        }

        // GET: Islem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            return View(islem);
        }

        // POST: Islem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Islem islem = db.Islem.Find(id);
            db.Islem.Remove(islem);
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
