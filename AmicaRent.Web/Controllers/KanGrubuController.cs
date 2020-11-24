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
    public class KanGrubuController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: KanGrubu
        public ActionResult Index()
        {
            return View(db.KanGrubu.ToList());
        }

        // GET: KanGrubu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanGrubu kanGrubu = db.KanGrubu.Find(id);
            if (kanGrubu == null)
            {
                return HttpNotFound();
            }
            return View(kanGrubu);
        }

        // GET: KanGrubu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KanGrubu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KanGrubu_ID,KanGrubu_Adi,KanGrubu_Status,KanGrubu_CreateDate")] KanGrubu kanGrubu)
        {
            if (ModelState.IsValid)
            {
                db.KanGrubu.Add(kanGrubu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kanGrubu);
        }

        // GET: KanGrubu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanGrubu kanGrubu = db.KanGrubu.Find(id);
            if (kanGrubu == null)
            {
                return HttpNotFound();
            }
            return View(kanGrubu);
        }

        // POST: KanGrubu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KanGrubu_ID,KanGrubu_Adi,KanGrubu_Status,KanGrubu_CreateDate")] KanGrubu kanGrubu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kanGrubu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kanGrubu);
        }

        // GET: KanGrubu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanGrubu kanGrubu = db.KanGrubu.Find(id);
            if (kanGrubu == null)
            {
                return HttpNotFound();
            }
            return View(kanGrubu);
        }

        // POST: KanGrubu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KanGrubu kanGrubu = db.KanGrubu.Find(id);
            db.KanGrubu.Remove(kanGrubu);
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
