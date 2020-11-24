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
    public class ServisController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: Servis
        public ActionResult Index()
        {
            return View(db.Servis.ToList());
        }

        // GET: Servis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // GET: Servis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Servis_ID,Arac_ID,Servis_ServisZamani,ServisFirma_ID,Servis_Notlar,Servis_Ucreti,Servis_CreateDate")] Servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Servis.Add(servis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servis);
        }

        // GET: Servis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: Servis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Servis_ID,Arac_ID,Servis_ServisZamani,ServisFirma_ID,Servis_Notlar,Servis_Ucreti,Servis_CreateDate")] Servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servis);
        }

        // GET: Servis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: Servis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servis servis = db.Servis.Find(id);
            db.Servis.Remove(servis);
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
