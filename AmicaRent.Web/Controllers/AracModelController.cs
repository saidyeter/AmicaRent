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
    public class AracModelController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: AracModel
        public ActionResult Index()
        {
            return View(db.viewAracModel.ToList());
        }

        // GET: AracModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aracModel = db.viewAracModel.SingleOrDefault(x => x.AracModel_ID == id);
            if (aracModel == null)
            {
                return HttpNotFound();
            }
            return View(aracModel);
        }

        // GET: AracModel/Create
        public ActionResult Create()
        {
            List<AracMarka> aracMarkaList = db.AracMarka.ToList();
            ViewBag.AracMarkaList = aracMarkaList;

            return View();
        }

        // POST: AracModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracModel_ID,AracMarka_ID,AracModel_Adi,AracModel_Status,AracModel_CreateDate")] AracModel aracModel)
        {
            if (ModelState.IsValid)
            {
                db.AracModel.Add(aracModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracModel);
        }

        // GET: AracModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracModel aracModel = db.AracModel.Find(id);
            if (aracModel == null)
            {
                return HttpNotFound();
            }
            List<AracMarka> aracMarkaList = db.AracMarka.ToList();
            ViewBag.AracMarkaList = aracMarkaList;

            return View(aracModel);
        }

        // POST: AracModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracModel_ID,AracMarka_ID,AracModel_Adi,AracModel_Status,AracModel_CreateDate")] AracModel aracModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracModel);
        }

        // GET: AracModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracModel aracModel = db.AracModel.Find(id);
            if (aracModel == null)
            {
                return HttpNotFound();
            }
            return View(aracModel);
        }

        // POST: AracModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AracModel aracModel = db.AracModel.Find(id);
            db.AracModel.Remove(aracModel);
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
