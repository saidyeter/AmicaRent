using AmicaRent.DataAccess;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RezervasyonOnKayitController : RootController
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

                var data = db.viewRezervasyonOnKayit.AsQueryable();

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m =>
                        m.Ad_Soyad.Contains(searchValue) ||
                        m.Plaka.Contains(searchValue) ||
                        m.Telefon.Contains(searchValue) ||
                        m.AlisLokasyonu.Contains(searchValue) ||
                        m.TeslimLokasyonu.Contains(searchValue));
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
            RezervasyonOnKayit model = db.RezervasyonOnKayit.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezervasyonOnKayit model = db.RezervasyonOnKayit.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            model.RezervasyonOnKayit_Durum = (int)RezervasyonOnKayitDurum.KabulEdildi;
            return RedirectToAction("Create", "Cari", new { RezervasyonOnKayitId = model.RezervasyonOnKayit_ID });
        }
        public ActionResult Decline(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezervasyonOnKayit model = db.RezervasyonOnKayit.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            model.RezervasyonOnKayit_Durum = (int)RezervasyonOnKayitDurum.Reddedildi;
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
