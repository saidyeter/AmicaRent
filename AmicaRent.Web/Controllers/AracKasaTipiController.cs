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
    public class AracKasaTipiController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: AracKasaTipi
        public ActionResult Index()
        {
            return View(db.AracKasaTipi.ToList());
        }

        // GET: AracKasaTipi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracKasaTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracKasaTipi_ID,AracKasaTipi_Adi,AracKasaTipi_Status,AracKasaTipi_CreateDate")] AracKasaTipi aracKasaTipi)
        {
            if (ModelState.IsValid)
            {
                db.AracKasaTipi.Add(aracKasaTipi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            return View(aracKasaTipi);
        }

        // POST: AracKasaTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracKasaTipi_ID,AracKasaTipi_Adi,AracKasaTipi_Status,AracKasaTipi_CreateDate")] AracKasaTipi aracKasaTipi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracKasaTipi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            return View(aracKasaTipi);
        }

        // POST: AracKasaTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            db.AracKasaTipi.Remove(aracKasaTipi);
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
