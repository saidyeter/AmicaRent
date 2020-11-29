using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataAccess;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class IslemTahsilatController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: IslemTahsilat
        public ActionResult Index()
        {
            return View(db.IslemTahsilat.Where(x => x.IslemTahsilat_Status == (int)DBStatus.Active).ToList());
        }

        // GET: IslemTahsilat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemTahsilat islemTahsilat = db.IslemTahsilat.Find(id);
            if (islemTahsilat == null)
            {
                return HttpNotFound();
            }
            return View(islemTahsilat);
        }

        // GET: IslemTahsilat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IslemTahsilat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IslemTahsilat_ID,Islem_ID,IslemTahsilat_Tarih,IslemTahsilat_Aciklama,OdemeTipi_ID,IslemTahsilat_Tutar,IslemTahsilat_CreateDate")] IslemTahsilat islemTahsilat)
        {
            if (ModelState.IsValid)
            {
                islemTahsilat.IslemTahsilat_Status = (int)DBStatus.Active;
                islemTahsilat.IslemTahsilat_CreateDate = DateTime.Now;
                db.IslemTahsilat.Add(islemTahsilat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(islemTahsilat);
        }

        // GET: IslemTahsilat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemTahsilat islemTahsilat = db.IslemTahsilat.Find(id);
            if (islemTahsilat == null)
            {
                return HttpNotFound();
            }
            return View(islemTahsilat);
        }

        // POST: IslemTahsilat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IslemTahsilat_ID,Islem_ID,IslemTahsilat_Tarih,IslemTahsilat_Aciklama,OdemeTipi_ID,IslemTahsilat_Tutar,IslemTahsilat_CreateDate")] IslemTahsilat islemTahsilat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(islemTahsilat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(islemTahsilat);
        }

        // GET: IslemTahsilat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemTahsilat islemTahsilat = db.IslemTahsilat.Find(id);
            if (islemTahsilat == null)
            {
                return HttpNotFound();
            }
            islemTahsilat.IslemTahsilat_Status = (int)DBStatus.Deleted;
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
