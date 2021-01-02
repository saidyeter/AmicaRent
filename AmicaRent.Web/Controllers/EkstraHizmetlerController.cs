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
    public class EkstraHizmetlerController : RootController
    {
        

        // GET: EkstraHizmetler
        public ActionResult Index()
        {
            return View(db.EkstraHizmetler.Where(x => x.EkstraHizmetler_Status == (int)DBStatus.Active).ToList());
        }

        // GET: EkstraHizmetler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkstraHizmetler ekstraHizmetler = db.EkstraHizmetler.Find(id);
            if (ekstraHizmetler == null)
            {
                return HttpNotFound();
            }
            return View(ekstraHizmetler);
        }

        // GET: EkstraHizmetler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EkstraHizmetler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EkstraHizmetler_ID,EkstraHizmetler_Adi,EkstraHizmetler_Ucreti,EkstraHizmetler_Status,EkstraHizmetler_CreateDate")] EkstraHizmetler ekstraHizmetler)
        {
            if (ModelState.IsValid)
            {
                ekstraHizmetler.EkstraHizmetler_Status = (int)DBStatus.Active;
                ekstraHizmetler.EkstraHizmetler_CreateDate = DateTime.Now;
                db.EkstraHizmetler.Add(ekstraHizmetler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ekstraHizmetler);
        }

        // GET: EkstraHizmetler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkstraHizmetler ekstraHizmetler = db.EkstraHizmetler.Find(id);
            if (ekstraHizmetler == null)
            {
                return HttpNotFound();
            }
            return View(ekstraHizmetler);
        }

        // POST: EkstraHizmetler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EkstraHizmetler_ID,EkstraHizmetler_Adi,EkstraHizmetler_Ucreti,EkstraHizmetler_Status,EkstraHizmetler_CreateDate")] EkstraHizmetler ekstraHizmetler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ekstraHizmetler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ekstraHizmetler);
        }

        // GET: EkstraHizmetler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkstraHizmetler ekstraHizmetler = db.EkstraHizmetler.Find(id);
            if (ekstraHizmetler == null)
            {
                return HttpNotFound();
            }
            ekstraHizmetler.EkstraHizmetler_Status = (int)DBStatus.Deleted;
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
