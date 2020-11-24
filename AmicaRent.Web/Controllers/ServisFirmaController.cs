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
    public class ServisFirmaController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: ServisFirma
        public ActionResult Index()
        {
            return View(db.ServisFirma.ToList());
        }

        // GET: ServisFirma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServisFirma servisFirma = db.ServisFirma.Find(id);
            if (servisFirma == null)
            {
                return HttpNotFound();
            }
            return View(servisFirma);
        }

        // GET: ServisFirma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServisFirma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServisFirma_ID,ServisFirma_Adi,ServisFirma_Adres1,ServisFirma_Adres2,ServisFirma_Tel1,ServisFirma_Tel2,ServisFirma_Email,ServisFirma_Yetkili,ServisFirma_CreateDate,ServisFirma_Status")] ServisFirma servisFirma)
        {
            if (ModelState.IsValid)
            {
                db.ServisFirma.Add(servisFirma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servisFirma);
        }

        // GET: ServisFirma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServisFirma servisFirma = db.ServisFirma.Find(id);
            if (servisFirma == null)
            {
                return HttpNotFound();
            }
            return View(servisFirma);
        }

        // POST: ServisFirma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServisFirma_ID,ServisFirma_Adi,ServisFirma_Adres1,ServisFirma_Adres2,ServisFirma_Tel1,ServisFirma_Tel2,ServisFirma_Email,ServisFirma_Yetkili,ServisFirma_CreateDate,ServisFirma_Status")] ServisFirma servisFirma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servisFirma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servisFirma);
        }

        // GET: ServisFirma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServisFirma servisFirma = db.ServisFirma.Find(id);
            if (servisFirma == null)
            {
                return HttpNotFound();
            }
            return View(servisFirma);
        }

        // POST: ServisFirma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServisFirma servisFirma = db.ServisFirma.Find(id);
            db.ServisFirma.Remove(servisFirma);
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
