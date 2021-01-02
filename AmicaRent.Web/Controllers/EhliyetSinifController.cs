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
    public class EhliyetSinifController : RootController
    {
        

        // GET: EhliyetSinif
        public ActionResult Index()
        {
            return View(db.EhliyetSinif.Where(x => x.EhliyetSinif_Status == (int)DBStatus.Active).ToList());
        }

        // GET: EhliyetSinif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EhliyetSinif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EhliyetSinif_ID,EhliyetSinif_Adi,EhliyetSinif_Status,EhliyetSinif_CreateDate")] EhliyetSinif ehliyetSinif)
        {
            if (ModelState.IsValid)
            {
                ehliyetSinif.EhliyetSinif_Status = (int)DBStatus.Active;
                ehliyetSinif.EhliyetSinif_CreateDate = DateTime.Now;
                db.EhliyetSinif.Add(ehliyetSinif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            return View(ehliyetSinif);
        }

        // POST: EhliyetSinif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EhliyetSinif_ID,EhliyetSinif_Adi,EhliyetSinif_Status,EhliyetSinif_CreateDate")] EhliyetSinif ehliyetSinif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ehliyetSinif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ehliyetSinif);
        }

        // GET: EhliyetSinif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EhliyetSinif ehliyetSinif = db.EhliyetSinif.Find(id);
            if (ehliyetSinif == null)
            {
                return HttpNotFound();
            }
            ehliyetSinif.EhliyetSinif_Status = (int)DBStatus.Deleted;
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
