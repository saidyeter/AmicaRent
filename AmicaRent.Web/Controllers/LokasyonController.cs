using AmicaRent.DataAccess;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LokasyonController : RootController
    {
        

        // GET: Lokasyon
        public ActionResult Index()
        {
            return View(db.Lokasyon.Where(x => x.Lokasyon_Status == (int)DBStatus.Active).ToList());
        }

        // GET: Lokasyon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            return View(lokasyon);
        }

        // GET: Lokasyon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokasyon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lokasyon_ID,Lokasyon_Adi,Lokasyon_Tipi,Lokasyon_Status,Lokasyon_CreateDate")] Lokasyon lokasyon)
        {
            if (ModelState.IsValid)
            {
                lokasyon.Lokasyon_Status = (int)DBStatus.Active;
                lokasyon.Lokasyon_CreateDate = DateTime.Now;
                db.Lokasyon.Add(lokasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokasyon);
        }

        // GET: Lokasyon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            return View(lokasyon);
        }

        // POST: Lokasyon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lokasyon_ID,Lokasyon_Adi,Lokasyon_Tipi,Lokasyon_Status,Lokasyon_CreateDate")] Lokasyon lokasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokasyon);
        }

        // GET: Lokasyon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokasyon lokasyon = db.Lokasyon.Find(id);
            if (lokasyon == null)
            {
                return HttpNotFound();
            }
            lokasyon.Lokasyon_Status = (int)DBStatus.Deleted;
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
