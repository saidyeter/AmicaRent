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
    public class CariEhliyetController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: CariEhliyet
        public ActionResult Index()
        {
            return View(db.CariEhliyet.ToList());
        }

        // GET: CariEhliyet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariEhliyet cariEhliyet = db.CariEhliyet.Find(id);
            if (cariEhliyet == null)
            {
                return HttpNotFound();
            }
            return View(cariEhliyet);
        }

        // GET: CariEhliyet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CariEhliyet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CariEhliyet_ID,Cari_ID,CariEhliyet_VerilisTarihi,CariEhliyet_GecerlilikTarihi,CariEhliyet_VerildigiYer,CariEhliyet_DogumYeri,CariEhliyet_EhliyetNumarasi,EhliyetSinif_ID,KanGrubu_ID")] CariEhliyet cariEhliyet)
        {
            if (ModelState.IsValid)
            {
                db.CariEhliyet.Add(cariEhliyet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cariEhliyet);
        }

        // GET: CariEhliyet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariEhliyet cariEhliyet = db.CariEhliyet.Find(id);
            if (cariEhliyet == null)
            {
                return HttpNotFound();
            }
            return View(cariEhliyet);
        }

        // POST: CariEhliyet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CariEhliyet_ID,Cari_ID,CariEhliyet_VerilisTarihi,CariEhliyet_GecerlilikTarihi,CariEhliyet_VerildigiYer,CariEhliyet_DogumYeri,CariEhliyet_EhliyetNumarasi,EhliyetSinif_ID,KanGrubu_ID")] CariEhliyet cariEhliyet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cariEhliyet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariEhliyet);
        }

        // GET: CariEhliyet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariEhliyet cariEhliyet = db.CariEhliyet.Find(id);
            if (cariEhliyet == null)
            {
                return HttpNotFound();
            }
            return View(cariEhliyet);
        }

        // POST: CariEhliyet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CariEhliyet cariEhliyet = db.CariEhliyet.Find(id);
            db.CariEhliyet.Remove(cariEhliyet);
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
