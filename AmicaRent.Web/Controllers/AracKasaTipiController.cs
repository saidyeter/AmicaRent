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
    public class AracKasaTipiController : RootController
    { 
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult LoadDt()
        {
            try
            {
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                var data = db.AracKasaTipi.Where(x => x.AracKasaTipi_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.AracKasaTipi_Adi.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracKasaTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracKasaTipi_ID,AracKasaTipi_Adi,AracKasaTipi_Status,AracKasaTipi_CreateDate")] AracKasaTipi aracKasaTipi)
        {
            if (ModelState.IsValid)
            {
                aracKasaTipi.AracKasaTipi_Status = (int)DBStatus.Active;
                aracKasaTipi.AracKasaTipi_CreateDate = DateTime.Now;
                db.AracKasaTipi.Add(aracKasaTipi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            return View(aracKasaTipi);
        }

        // POST: AracKasaTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracKasaTipi_ID,AracKasaTipi_Adi,AracKasaTipi_Status,AracKasaTipi_CreateDate")] AracKasaTipi aracKasaTipi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracKasaTipi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracKasaTipi);
        }

        // GET: AracKasaTipi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracKasaTipi aracKasaTipi = db.AracKasaTipi.Find(id);
            if (aracKasaTipi == null)
            {
                return HttpNotFound();
            }
            aracKasaTipi.AracKasaTipi_Status = (int)DBStatus.Deleted;
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
