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
using WebApplication.Models.ViewModels;

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
            return View();
        }

        public ActionResult IndexReserved()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadDtIndexAvailable()
        {
            try
            {
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                var data = db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active && x.AracKiralamaDurumu == (int)AracDurumu.Bos);

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
        [HttpPost]
        public JsonResult LoadDtIndexReserved()
        {
            try
            {
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                var data = db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active && x.AracKiralamaDurumu == (int)AracDurumu.Musteride);

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
            AracViewModel model = new AracViewModel { Arac_KrediKullanimi = false };
            return View(model);
        }

        // POST: Arac/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AracViewModel model, List<HttpPostedFileBase> aracResimleri)
        {
            if (model.Arac_KrediKullanimi)
            {
                bool krediAlanEksik = false;
                string ErrorMessage = "Gerekli.";
                if (model.Arac_KrediTaksitOdemeGunu is null) { krediAlanEksik = true; ModelState.AddModelError("Arac_KrediTaksitOdemeGunu", ErrorMessage); }
                if (model.Arac_KrediTaksitSayisi is null) { krediAlanEksik = true; ModelState.AddModelError("Arac_KrediTaksitSayisi", ErrorMessage); }
                if (model.Arac_KrediTaksitTutari is null) { krediAlanEksik = true; ModelState.AddModelError("Arac_KrediTaksitTutari", ErrorMessage); }
                if (model.Arac_KrediBankaID is null) { krediAlanEksik = true; ModelState.AddModelError("Arac_KrediTaksitTutari", ErrorMessage); }
                if (krediAlanEksik)
                {
                    ModelState.AddModelError("Arac_KrediKullanimi", "Kredi Kullanımı varsa alttaki tüm alanlar dolmalıdır. Yoksa hepsi boş olmalıdır.");
                }
            }
            if (ModelState.IsValid)
            {

                Arac arac = new Arac
                {
                    AracGrup_ID = (int)model.AracGrup_ID,
                    AracGuncelKM = model.AracGuncelKM,
                    AracKasaTipi_ID = (int)model.AracKasaTipi_ID,
                    AracKiralamaDurumu = (int)AracDurumu.Bos,
                    AracKlimaDurumu = (int)model.AracKlimaDurumu,
                    AracMarka_ID = (int)model.AracMarka_ID,
                    AracModel_ID = (int)model.AracModel_ID,
                    AracMotorNo = model.AracMotorNo,
                    AracPlakaNo = model.AracPlakaNo,
                    AracRenk_ID = (int)model.AracRenk_ID,
                    AracRuhsatSeriNo = model.AracRuhsatSeriNo,
                    AracSaseNo = model.AracSaseNo,
                    AracYakitTuru_ID = (int)model.AracYakitTuru_ID,
                    Arac_AsimUcreti = (int)model.Arac_AsimUcreti,
                    Arac_FenniMuayeneGecerlilikTarihi = (DateTime)model.Arac_FenniMuayeneGecerlilikTarihi,
                    Arac_KaskoBitisTarihi = (DateTime)model.Arac_KaskoBitisTarihi,
                    Arac_KoltukSigortasiBitisTarihi = (DateTime)model.Arac_KoltukSigortasiBitisTarihi,
                    Arac_Status = (int)DBStatus.Active,
                    Arac_TrafikSigortasiBitisTarihi = (DateTime)model.Arac_TrafikSigortasiBitisTarihi,
                    Arac_VitesTipi = (int)model.Arac_VitesTipi,
                    Arac_Yil = model.Arac_Yil,
                };
                db.Arac.Add(arac);
                db.SaveChanges();
                if (model.Arac_KrediKullanimi)
                {
                    /*
                     Arac_KrediTaksitOdemeGunu = 19u diyelim
                    bugün ayın 16sı ise ilk taksit bu ayın 19u olur
                    bugün ayın 20si ise ilk taksit bir sonraki ayın 19u olur                     
                     */

                    var firstPayment = DateTime.Now;
                    if (DateTime.Now.Day < model.Arac_KrediTaksitOdemeGunu)
                    {
                        firstPayment = new DateTime(DateTime.Now.Year, DateTime.Now.Month, (int)model.Arac_KrediTaksitOdemeGunu);
                    }
                    else
                    {
                        firstPayment = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, (int)model.Arac_KrediTaksitOdemeGunu);
                    }
                    for (int i = 0; i < (int)model.Arac_KrediTaksitSayisi; i++)
                    {
                        AracKredi aracKredi = new AracKredi
                        {
                            AracKredi_KrediTutar = (int)model.Arac_KrediTaksitTutari,
                            AracKredi_OdemeTarihi = firstPayment.AddMonths(i),
                            AracKredi_Odendi = false,
                            Arac_ID = arac.Arac_ID,
                            Banka_ID = (int)model.Arac_KrediBankaID
                        };
                        db.AracKredi.Add(aracKredi);
                    }
                }
                foreach (var item in aracResimleri)
                {
                    if (item != null)
                    {
                        try
                        {
                            var itemId = SaveFile(item.InputStream, item.FileName);
                            var file = new AracFile();
                            file.Arac_ID = arac.Arac_ID;
                            file.SysFile_ID = itemId;
                            db.AracFile.Add(file);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
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


            AracViewModel model = new AracViewModel
            {
                AracGrup_ID = (int)arac.AracGrup_ID,
                AracGuncelKM = arac.AracGuncelKM,
                AracKasaTipi_ID = (int)arac.AracKasaTipi_ID,
                AracKlimaDurumu = (int)arac.AracKlimaDurumu,
                AracMarka_ID = (int)arac.AracMarka_ID,
                AracModel_ID = (int)arac.AracModel_ID,
                AracMotorNo = arac.AracMotorNo,
                AracPlakaNo = arac.AracPlakaNo,
                AracRenk_ID = (int)arac.AracRenk_ID,
                AracRuhsatSeriNo = arac.AracRuhsatSeriNo,
                AracSaseNo = arac.AracSaseNo,
                AracYakitTuru_ID = (int)arac.AracYakitTuru_ID,
                Arac_AsimUcreti = (int)arac.Arac_AsimUcreti,
                Arac_FenniMuayeneGecerlilikTarihi = (DateTime)arac.Arac_FenniMuayeneGecerlilikTarihi,
                Arac_KaskoBitisTarihi = (DateTime)arac.Arac_KaskoBitisTarihi,
                Arac_KoltukSigortasiBitisTarihi = (DateTime)arac.Arac_KoltukSigortasiBitisTarihi,
                Arac_TrafikSigortasiBitisTarihi = (DateTime)arac.Arac_TrafikSigortasiBitisTarihi,
                Arac_VitesTipi = (int)arac.Arac_VitesTipi,
                Arac_Yil = arac.Arac_Yil,
            };
            ViewBag.AracGrup = db.AracGrup.Find(model.AracGrup_ID).AracGrup_Adi;
            ViewBag.AracKasaTipi = db.AracKasaTipi.Find(model.AracKasaTipi_ID).AracKasaTipi_Adi;
            ViewBag.AracMarka = db.AracMarka.Find(model.AracMarka_ID).AracMarka_Adi;
            ViewBag.AracModel = db.AracModel.Find(model.AracModel_ID).AracModel_Adi;
            ViewBag.AracRenk = db.AracRenk.Find(model.AracRenk_ID).AracRenk_Adi;
            ViewBag.AracYakitTuru = db.AracYakitTuru.Find(model.AracYakitTuru_ID).AracYakitTuru_Adi;


            return View(model);
        }

        // POST: Arac/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AracViewModel model, int? id)
        {
            Arac arac = db.Arac.Find(id);

            if (ModelState.IsValid)
            {
                arac.AracGrup_ID = (int)model.AracGrup_ID;
                arac.AracGuncelKM = model.AracGuncelKM;
                arac.AracKasaTipi_ID = (int)model.AracKasaTipi_ID;
                arac.AracKiralamaDurumu = (int)AracDurumu.Bos;
                arac.AracKlimaDurumu = (int)model.AracKlimaDurumu;
                arac.AracMarka_ID = (int)model.AracMarka_ID;
                arac.AracModel_ID = (int)model.AracModel_ID;
                arac.AracMotorNo = model.AracMotorNo;
                arac.AracPlakaNo = model.AracPlakaNo;
                arac.AracRenk_ID = (int)model.AracRenk_ID;
                arac.AracRuhsatSeriNo = model.AracRuhsatSeriNo;
                arac.AracSaseNo = model.AracSaseNo;
                arac.AracYakitTuru_ID = (int)model.AracYakitTuru_ID;
                arac.Arac_AsimUcreti = (int)model.Arac_AsimUcreti;
                arac.Arac_FenniMuayeneGecerlilikTarihi = (DateTime)model.Arac_FenniMuayeneGecerlilikTarihi;
                arac.Arac_KaskoBitisTarihi = (DateTime)model.Arac_KaskoBitisTarihi;
                arac.Arac_KoltukSigortasiBitisTarihi = (DateTime)model.Arac_KoltukSigortasiBitisTarihi;
                arac.Arac_Status = (int)DBStatus.Active;
                arac.Arac_TrafikSigortasiBitisTarihi = (DateTime)model.Arac_TrafikSigortasiBitisTarihi;
                arac.Arac_VitesTipi = (int)model.Arac_VitesTipi;
                arac.Arac_Yil = model.Arac_Yil;
                db.Entry(arac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arac);
        }

        public ActionResult SendToService(int? id)
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

            arac.AracKiralamaDurumu = (int)AracDurumu.Serviste;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int? id)
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

            arac.AracKiralamaDurumu = (int)AracDurumu.Pasif;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
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
