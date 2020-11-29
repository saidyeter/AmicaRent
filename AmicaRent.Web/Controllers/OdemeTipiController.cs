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
    public class OdemeTipiController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: OdemeTipi
        public ActionResult Index()
        {
            return View(db.OdemeTipi.Where(x => x.OdemeTipi_Status == (int)DBStatus.Active).ToList());
        }

        // GET: OdemeTipi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTipi odemeTipi = db.OdemeTipi.Find(id);
            if (odemeTipi == null)
            {
                return HttpNotFound();
            }
            return View(odemeTipi);
        }

        // GET: OdemeTipi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OdemeTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdemeTipi_ID,OdemeTipi_Adi,OdemeTipi_Status,OdemeTipi_CreateDate")] OdemeTipi odemeTipi)
        {
            if (ModelState.IsValid)
            {
                odemeTipi.OdemeTipi_Status = (int)DBStatus.Active;
                odemeTipi.OdemeTipi_CreateDate = DateTime.Now;
                db.OdemeTipi.Add(odemeTipi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odemeTipi);
        }

        // GET: OdemeTipi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTipi odemeTipi = db.OdemeTipi.Find(id);
            if (odemeTipi == null)
            {
                return HttpNotFound();
            }
            return View(odemeTipi);
        }

        // POST: OdemeTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdemeTipi_ID,OdemeTipi_Adi,OdemeTipi_Status,OdemeTipi_CreateDate")] OdemeTipi odemeTipi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odemeTipi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odemeTipi);
        }

        // GET: OdemeTipi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTipi odemeTipi = db.OdemeTipi.Find(id);
            if (odemeTipi == null)
            {
                return HttpNotFound();
            }
            odemeTipi.OdemeTipi_Status = (int)DBStatus.Deleted;
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
