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
    public class EkSurucuController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: EkSurucu
        public ActionResult Index()
        {
            return View(db.EkSurucu.Where(x => x.EkSurucu_Status == (int)DBStatus.Active).ToList());
        }

        // GET: EkSurucu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkSurucu ekSurucu = db.EkSurucu.Find(id);
            if (ekSurucu == null)
            {
                return HttpNotFound();
            }
            return View(ekSurucu);
        }

        // GET: EkSurucu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EkSurucu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EkSurucu_ID,Cari_ID,EkSurucu_CreateDate")] EkSurucu ekSurucu)
        {
            if (ModelState.IsValid)
            {
                ekSurucu.EkSurucu_Status = (int)DBStatus.Active;
                ekSurucu.EkSurucu_CreateDate = DateTime.Now;
                db.EkSurucu.Add(ekSurucu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ekSurucu);
        }

        // GET: EkSurucu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkSurucu ekSurucu = db.EkSurucu.Find(id);
            if (ekSurucu == null)
            {
                return HttpNotFound();
            }
            return View(ekSurucu);
        }

        // POST: EkSurucu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EkSurucu_ID,Cari_ID,EkSurucu_CreateDate")] EkSurucu ekSurucu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ekSurucu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ekSurucu);
        }

        // GET: EkSurucu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkSurucu ekSurucu = db.EkSurucu.Find(id);
            if (ekSurucu == null)
            {
                return HttpNotFound();
            }
            ekSurucu.EkSurucu_Status = (int)DBStatus.Deleted;
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
