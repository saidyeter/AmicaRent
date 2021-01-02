using AmicaRent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using AmicaRent.DataAccess;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AracController : RootController
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

                var data = db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.AracPlakaNo.Contains(searchValue) || m.AracMarka_Adi.Contains(searchValue) || m.AracModel_Adi.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult IndexAvailable()
        {
            return View(db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active && x.KiralamaDurumu == "Boşta").ToList());
        }

        public ActionResult IndexReserved()
        {
            return View(db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active && x.KiralamaDurumu != "Boşta").ToList());
        }
        // GET: Arac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var arac = db.viewAracList.SingleOrDefault(x => x.Arac_ID == id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }

        // GET: Arac/Create
        public ActionResult Create()
        {

            List<AracGrup> aracGrupList = db.AracGrup.Where(x => x.AracGrup_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracGrupList = aracGrupList;
            List<AracMarka> aracMarkaList = db.AracMarka.Where(x => x.AracMarka_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracMarkaList = aracMarkaList;
            List<AracModel> aracModelList = db.AracModel.Where(x => x.AracModel_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracModelList = aracModelList;
            List<AracYakitTuru> aracYakitTuruList = db.AracYakitTuru.Where(x => x.AracYakitTuru_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracYakitTuruList = aracYakitTuruList;

            Dictionary<string, string> vitesTipi = new Dictionary<string, string>();
            vitesTipi.Add("OTOMATİK", "OTOMATİK");
            vitesTipi.Add("MANUEL", "MANUEL");
            ViewBag.VitesTipi = vitesTipi;

            List<AracKasaTipi> aracKasaTipiList = db.AracKasaTipi.Where(x => x.AracKasaTipi_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracKasaTipiList = aracKasaTipiList;

            Dictionary<int, string> aracKlimaDurumu = new Dictionary<int, string>();
            aracKlimaDurumu.Add(1, "Klimalı");
            aracKlimaDurumu.Add(2, "Klimasız");
            ViewBag.AracKlimaDurumu = aracKlimaDurumu;

            List<AracRenk> aracRenkList = db.AracRenk.Where(x => x.AracRenk_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracRenkList = aracRenkList;


            Dictionary<int, string> aracKiralamaDurumu = new Dictionary<int, string>();
            aracKiralamaDurumu.Add(0, "Boşta");
            aracKiralamaDurumu.Add(1, "Müşteride");
            aracKiralamaDurumu.Add(2, "Pasif Araç");
            aracKiralamaDurumu.Add(3, "Arızalı/Serviste");
            ViewBag.AracKiralamaDurumu = aracKiralamaDurumu;



            return View();
        }

        // POST: Arac/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Arac_ID,AracGrup_ID,AracMarka_ID,AracModel_ID,Arac_Yil,AracYakitTuru_ID,Arac_VitesTipi,AracKasaTipi_ID,AracKlimaDurumu,AracPlakaNo,AracGuncelKM,AracMotorNo,AracSaseNo,AracRuhsatSeriNo,Arac_Status,AracRenk_ID,AracKiralamaDurumu,Arac_TrafikSigortasiBitisTarihi,Arac_KaskoBitisTarihi,Arac_KoltukSigortasiBitisTarihi,Arac_FenniMuayeneGecerlilikTarihi")] Arac arac)
        {
            if (ModelState.IsValid)
            {
                arac.Arac_Status = (int)DBStatus.Active;
                db.Arac.Add(arac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arac);
        }

        // GET: Arac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arac arac = db.Arac.Find(id);
            if (arac == null)
            {
                return HttpNotFound();
            }



            List<AracGrup> aracGrupList = db.AracGrup.Where(x => x.AracGrup_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracGrupList = aracGrupList;
            List<AracMarka> aracMarkaList = db.AracMarka.Where(x => x.AracMarka_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracMarkaList = aracMarkaList;
            List<AracModel> aracModelList = db.AracModel.Where(x => x.AracModel_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracModelList = aracModelList;
            List<AracYakitTuru> aracYakitTuruList = db.AracYakitTuru.Where(x => x.AracYakitTuru_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracYakitTuruList = aracYakitTuruList;

            Dictionary<string, string> vitesTipi = new Dictionary<string, string>();
            vitesTipi.Add("OTOMATİK", "OTOMATİK");
            vitesTipi.Add("MANUEL", "MANUEL");
            ViewBag.VitesTipi = vitesTipi;

            List<AracKasaTipi> aracKasaTipiList = db.AracKasaTipi.Where(x => x.AracKasaTipi_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracKasaTipiList = aracKasaTipiList;

            Dictionary<int, string> aracKlimaDurumu = new Dictionary<int, string>();
            aracKlimaDurumu.Add(1, "Klimalı");
            aracKlimaDurumu.Add(2, "Klimasız");
            ViewBag.AracKlimaDurumu = aracKlimaDurumu;

            List<AracRenk> aracRenkList = db.AracRenk.Where(x => x.AracRenk_Status == (int)DBStatus.Active).ToList();
            ViewBag.AracRenkList = aracRenkList;


            Dictionary<int, string> aracKiralamaDurumu = new Dictionary<int, string>();
            aracKiralamaDurumu.Add(0, "Boşta");
            aracKiralamaDurumu.Add(1, "Müşteride");
            aracKiralamaDurumu.Add(2, "Pasif Araç");
            aracKiralamaDurumu.Add(3, "Arızalı/Serviste");
            ViewBag.AracKiralamaDurumu = aracKiralamaDurumu;



            return View(arac);
        }

        // POST: Arac/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Arac_ID,AracGrup_ID,AracMarka_ID,AracModel_ID,Arac_Yil,AracYakitTuru_ID,Arac_VitesTipi,AracKasaTipi_ID,AracKlimaDurumu,AracPlakaNo,AracGuncelKM,AracMotorNo,AracSaseNo,AracRuhsatSeriNo,Arac_Status,AracRenk_ID,AracKiralamaDurumu,Arac_TrafikSigortasiBitisTarihi,Arac_KaskoBitisTarihi,Arac_KoltukSigortasiBitisTarihi,Arac_FenniMuayeneGecerlilikTarihi")] Arac arac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arac);
        }

        // GET: Arac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arac arac = db.Arac.Find(id);

            if (arac == null)
            {
                return HttpNotFound();
            }

            arac.Arac_Status = (int)DBStatus.Deleted;
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
