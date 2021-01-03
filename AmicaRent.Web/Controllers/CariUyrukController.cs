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
    public class CariUyrukController : RootController
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

                var data = db.CariUyruk.Where(x => x.CariUyruk_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.CariUyruk_Adi.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: CariUyruk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariUyruk cariUyruk = db.CariUyruk.Find(id);
            if (cariUyruk == null)
            {
                return HttpNotFound();
            }
            return View(cariUyruk);
        }

        // GET: CariUyruk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CariUyruk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CariUyruk_ID,CariUyruk_Adi,CariUyruk_Status,CariUyruk_CreateDate")] CariUyruk cariUyruk)
        {
            if (ModelState.IsValid)
            {
                cariUyruk.CariUyruk_Status = (int)DBStatus.Active;
                cariUyruk.CariUyruk_CreateDate = DateTime.Now;
                db.CariUyruk.Add(cariUyruk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cariUyruk);
        }

        // GET: CariUyruk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariUyruk cariUyruk = db.CariUyruk.Find(id);
            if (cariUyruk == null)
            {
                return HttpNotFound();
            }
            return View(cariUyruk);
        }

        // POST: CariUyruk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CariUyruk_ID,CariUyruk_Adi,CariUyruk_Status,CariUyruk_CreateDate")] CariUyruk cariUyruk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cariUyruk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariUyruk);
        }

        // GET: CariUyruk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CariUyruk cariUyruk = db.CariUyruk.Find(id);
            if (cariUyruk == null)
            {
                return HttpNotFound();
            }
            cariUyruk.CariUyruk_Status = (int)DBStatus.Deleted;
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
