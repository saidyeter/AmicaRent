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
    public class ServisController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        // GET: Servis
        public ActionResult Index()
        {
            return View(db.viewServis.Where(x => x.Servis_Status == (int)DBStatus.Active).ToList());
        }

        // GET: Servis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var servis = db.viewServis.SingleOrDefault(x => x.Servis_ID == id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // GET: Servis/Create
        public ActionResult Create()
        {

            List<ServisFirma> servisFirmalist = db.ServisFirma.Where(x => x.ServisFirma_Status == (int)DBStatus.Active).ToList();
            ViewBag.ServisFirmalist = servisFirmalist;

            Dictionary<int, string> aracList = new Dictionary<int, string>();
            foreach (var arac in db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active).ToList())
            {
                aracList.Add(arac.Arac_ID, arac.AracGrup_Adi + " " + arac.AracMarka_Adi + " " + arac.AracModel_Adi + " " + arac.Arac_Yil);
            }
            ViewBag.AracList = aracList;


            return View();
        }

        // POST: Servis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Servis_ID,Arac_ID,Servis_ServisZamani,ServisFirma_ID,Servis_Notlar,Servis_Ucreti,Servis_CreateDate")] Servis servis)
        {
            if (ModelState.IsValid)
            {
                servis.Servis_Status = (int)DBStatus.Active;
                servis.Servis_CreateDate = DateTime.Now;
                db.Servis.Add(servis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servis);
        }

        // GET: Servis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }

            List<ServisFirma> servisFirmalist = db.ServisFirma.Where(x => x.ServisFirma_Status == (int)DBStatus.Active).ToList();
            ViewBag.ServisFirmalist = servisFirmalist;

            Dictionary<int, string> aracList = new Dictionary<int, string>();
            foreach (var arac in db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active).ToList())
            {
                aracList.Add(arac.Arac_ID, arac.AracGrup_Adi + " " + arac.AracMarka_Adi + " " + arac.AracModel_Adi + " " + arac.Arac_Yil);
            }
            ViewBag.AracList = aracList;

            return View(servis);
        }

        // POST: Servis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Servis_ID,Arac_ID,Servis_ServisZamani,ServisFirma_ID,Servis_Notlar,Servis_Ucreti,Servis_CreateDate")] Servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servis);
        }

        // GET: Servis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            servis.Servis_Status = (int)DBStatus.Deleted;
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
