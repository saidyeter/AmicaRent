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
    public class CariSehirController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: CariSehir
        public ActionResult Index()
        {
            return View(db.CariSehir.Where(x => x.CariSehir_Status == (int)DBStatus.Active).ToList());
        }

        // GET: CariSehir/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariSehir cariSehir = db.CariSehir.Find(id);
            if (cariSehir == null)
            {
                return HttpNotFound();
            }
            return View(cariSehir);
        }

        // GET: CariSehir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CariSehir/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CariSehir_ID,CariSehir_Adi,CariSehir_Status,CariSehir_CreateDate")] CariSehir cariSehir)
        {
            if (ModelState.IsValid)
            {
                cariSehir.CariSehir_Status = (int)DBStatus.Active;
                cariSehir.CariSehir_CreateDate = DateTime.Now;
                db.CariSehir.Add(cariSehir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cariSehir);
        }

        // GET: CariSehir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariSehir cariSehir = db.CariSehir.Find(id);
            if (cariSehir == null)
            {
                return HttpNotFound();
            }
            return View(cariSehir);
        }

        // POST: CariSehir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CariSehir_ID,CariSehir_Adi,CariSehir_Status,CariSehir_CreateDate")] CariSehir cariSehir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cariSehir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariSehir);
        }

        // GET: CariSehir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariSehir cariSehir = db.CariSehir.Find(id);
            if (cariSehir == null)
            {
                return HttpNotFound();
            }
            cariSehir.CariSehir_Status = (int)DBStatus.Deleted;
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
