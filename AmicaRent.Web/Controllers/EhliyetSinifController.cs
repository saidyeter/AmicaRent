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
    public class EhliyetSinifController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: EhliyetSinif
        public ActionResult Index()
        {
            return View(db.EhliyetSinif.ToList());
        }

        // GET: EhliyetSinif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EhliyetSinif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EhliyetSinif_ID,EhliyetSinif_Adi,EhliyetSinif_Status,EhliyetSinif_CreateDate")] EhliyetSinif ehliyetSinif)
        {
            if (ModelState.IsValid)
            {
                db.EhliyetSinif.Add(ehliyetSinif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            return View(ehliyetSinif);
        }

        // POST: EhliyetSinif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EhliyetSinif_ID,EhliyetSinif_Adi,EhliyetSinif_Status,EhliyetSinif_CreateDate")] EhliyetSinif ehliyetSinif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ehliyetSinif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            return View(ehliyetSinif);
        }

        // POST: EhliyetSinif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            db.EhliyetSinif.Remove(ehliyetSinif);
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
