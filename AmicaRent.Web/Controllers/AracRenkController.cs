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
    public class AracRenkController : RootController
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

                var data = db.AracRenk.Where(x => x.AracRenk_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.AracRenk_Adi.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: AracRenk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            return View(aracRenk);
        }

        // GET: AracRenk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AracRenk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracRenk_ID,AracRenk_Adi,AracRenk_Status,AracRenk_CreateDate")] AracRenk aracRenk)
        {
            if (ModelState.IsValid)
            {
                aracRenk.AracRenk_Status = (int)DBStatus.Active;
                aracRenk.AracRenk_CreateDate = DateTime.Now;
                db.AracRenk.Add(aracRenk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracRenk);
        }

        // GET: AracRenk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            return View(aracRenk);
        }

        // POST: AracRenk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracRenk_ID,AracRenk_Adi,AracRenk_Status,AracRenk_CreateDate")] AracRenk aracRenk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracRenk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracRenk);
        }

        // GET: AracRenk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            aracRenk.AracRenk_Status = (int)DBStatus.Deleted;
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
