using AmicaRent.DataAccess;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AracMarkaController : RootController
    {
        

        // GET: AracMarka
        public ActionResult Index()
        {
            return View(db.AracMarka.Where(x => x.AracMarka_Status == (int)DBStatus.Active).ToList());
        }

        // GET: AracMarka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracMarka aracMarka = db.AracMarka.Find(id);
            if (aracMarka == null)
            {
                return HttpNotFound();
            }
            return View(aracMarka);
        }

        // GET: AracMarka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracMarka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracMarka_ID,AracMarka_Adi,AracMarka_Status,AracMarka_CreateDate")] AracMarka aracMarka)
        {
            if (ModelState.IsValid)
            {
                aracMarka.AracMarka_Status = (int)DBStatus.Active;
                aracMarka.AracMarka_CreateDate = DateTime.Now;
                db.AracMarka.Add(aracMarka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracMarka);
        }

        // GET: AracMarka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracMarka aracMarka = db.AracMarka.Find(id);
            if (aracMarka == null)
            {
                return HttpNotFound();
            }
            return View(aracMarka);
        }

        // POST: AracMarka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracMarka_ID,AracMarka_Adi,AracMarka_Status,AracMarka_CreateDate")] AracMarka aracMarka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracMarka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracMarka);
        }

        // GET: AracMarka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracMarka aracMarka = db.AracMarka.Find(id);
            if (aracMarka == null)
            {
                return HttpNotFound();
            }
            aracMarka.AracMarka_Status = (int)DBStatus.Deleted;
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
