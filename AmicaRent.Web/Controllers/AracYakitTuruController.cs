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
    public class AracYakitTuruController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: AracYakitTuru
        public ActionResult Index()
        {
            return View(db.AracYakitTuru.ToList());
        }

        // GET: AracYakitTuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracYakitTuru aracYakitTuru = db.AracYakitTuru.Find(id);
            if (aracYakitTuru == null)
            {
                return HttpNotFound();
            }
            return View(aracYakitTuru);
        }

        // GET: AracYakitTuru/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracYakitTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracYakitTuru_ID,AracYakitTuru_Adi,AracYakitTuru_Status,AracYakitTuru_CreateDate")] AracYakitTuru aracYakitTuru)
        {
            if (ModelState.IsValid)
            {
                db.AracYakitTuru.Add(aracYakitTuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracYakitTuru);
        }

        // GET: AracYakitTuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracYakitTuru aracYakitTuru = db.AracYakitTuru.Find(id);
            if (aracYakitTuru == null)
            {
                return HttpNotFound();
            }
            return View(aracYakitTuru);
        }

        // POST: AracYakitTuru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracYakitTuru_ID,AracYakitTuru_Adi,AracYakitTuru_Status,AracYakitTuru_CreateDate")] AracYakitTuru aracYakitTuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracYakitTuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracYakitTuru);
        }

        // GET: AracYakitTuru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracYakitTuru aracYakitTuru = db.AracYakitTuru.Find(id);
            if (aracYakitTuru == null)
            {
                return HttpNotFound();
            }
            return View(aracYakitTuru);
        }

        // POST: AracYakitTuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AracYakitTuru aracYakitTuru = db.AracYakitTuru.Find(id);
            db.AracYakitTuru.Remove(aracYakitTuru);
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
