using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;
using AmicaRent.DataAccess;

namespace WebApplication.Controllers
{
    public class AracGrupController : RootController
    { 

        // GET: AracGrup
        public ActionResult Index()
        {
            return View(db.AracGrup.Where(x => x.AracGrup_Status == (int)DBStatus.Active).ToList());
        }

        // GET: AracGrup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracGrup aracGrup = db.AracGrup.Find(id);
            if (aracGrup == null)
            {
                return HttpNotFound();
            }
            return View(aracGrup);
        }

        // GET: AracGrup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracGrup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracGrup_ID,AracGrup_Adi,AracGrup_Status,AracGrup_CreateDate")] AracGrup aracGrup)
        {
            if (ModelState.IsValid)
            {
                aracGrup.AracGrup_Status = (int)DBStatus.Active;
                aracGrup.AracGrup_CreateDate = DateTime.Now;
                db.AracGrup.Add(aracGrup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracGrup);
        }

        // GET: AracGrup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracGrup aracGrup = db.AracGrup.Find(id);
            if (aracGrup == null)
            {
                return HttpNotFound();
            }
            return View(aracGrup);
        }

        // POST: AracGrup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracGrup_ID,AracGrup_Adi,AracGrup_Status,AracGrup_CreateDate")] AracGrup aracGrup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracGrup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracGrup);
        }

        // GET: AracGrup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracGrup aracGrup = db.AracGrup.Find(id);
            if (aracGrup == null)
            {
                return HttpNotFound();
            }
            aracGrup.AracGrup_Status = (int)DBStatus.Deleted;
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
