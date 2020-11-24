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
    public class IslemEkstraHizmetlerController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: IslemEkstraHizmetler
        public ActionResult Index()
        {
            return View(db.IslemEkstraHizmetler.ToList());
        }

        // GET: IslemEkstraHizmetler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemEkstraHizmetler islemEkstraHizmetler = db.IslemEkstraHizmetler.Find(id);
            if (islemEkstraHizmetler == null)
            {
                return HttpNotFound();
            }
            return View(islemEkstraHizmetler);
        }

        // GET: IslemEkstraHizmetler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IslemEkstraHizmetler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IslemEkstraHizmetler_ID,Islem_ID,EkstraHizmetler_ID,IslemEkstraHizmetler_CreateDate")] IslemEkstraHizmetler islemEkstraHizmetler)
        {
            if (ModelState.IsValid)
            {
                db.IslemEkstraHizmetler.Add(islemEkstraHizmetler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(islemEkstraHizmetler);
        }

        // GET: IslemEkstraHizmetler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemEkstraHizmetler islemEkstraHizmetler = db.IslemEkstraHizmetler.Find(id);
            if (islemEkstraHizmetler == null)
            {
                return HttpNotFound();
            }
            return View(islemEkstraHizmetler);
        }

        // POST: IslemEkstraHizmetler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IslemEkstraHizmetler_ID,Islem_ID,EkstraHizmetler_ID,IslemEkstraHizmetler_CreateDate")] IslemEkstraHizmetler islemEkstraHizmetler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(islemEkstraHizmetler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(islemEkstraHizmetler);
        }

        // GET: IslemEkstraHizmetler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IslemEkstraHizmetler islemEkstraHizmetler = db.IslemEkstraHizmetler.Find(id);
            if (islemEkstraHizmetler == null)
            {
                return HttpNotFound();
            }
            return View(islemEkstraHizmetler);
        }

        // POST: IslemEkstraHizmetler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IslemEkstraHizmetler islemEkstraHizmetler = db.IslemEkstraHizmetler.Find(id);
            db.IslemEkstraHizmetler.Remove(islemEkstraHizmetler);
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
