using AmicaRent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CariController : RootController
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

                var data = db.viewCari.Where(x => x.Cari_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.Cari_AdSoyad.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // GET: Cari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cari = db.viewCari.SingleOrDefault(x => x.Cari_ID == id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // GET: Cari/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CariViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Cari cari = new Cari
            {
                Cari_CreateDate = DateTime.Now,
                Cari_Status = (int)DBStatus.Active,
                CariSehir_ID = model.CariSehir_ID,
                Cari_Adres1 = model.Cari_Adres1,
                Cari_Adres2 = model.Cari_Adres2,
                Cari_AdSoyad = model.Cari_AdSoyad,
                Cari_Cinsiyet = model.Cari_Cinsiyet,
                Cari_DogumTarihi = model.Cari_DogumTarihi,
                Cari_EpostaAdresi = model.Cari_EpostaAdresi,
                Cari_IDNumber = model.Cari_IDNumber,
                Cari_LokalTelefon = model.Cari_LokalTelefon,
                Cari_MobilTelefon = model.Cari_MobilTelefon,
                Cari_UyrukID = model.Cari_UyrukID,
                Cari_Tipi = (int)model.Cari_Tipi,
                Cari_VergiDairesi = model.Cari_VergiDairesi,
                Cari_VergiNo = model.Cari_VergiNo
            };
            db.Cari.Add(cari);
            db.SaveChanges();
            CariEhliyet cariEhliyet = new CariEhliyet
            {
                Cari_ID = cari.Cari_ID,
                CariEhliyet_DogumYeri = model.CariEhliyet_DogumYeri,
                CariEhliyet_EhliyetNumarasi = model.CariEhliyet_EhliyetNumarasi,
                CariEhliyet_GecerlilikTarihi = model.CariEhliyet_GecerlilikTarihi,
                CariEhliyet_Status = (int)DBStatus.Active,
                CariEhliyet_VerildigiYer = model.CariEhliyet_VerildigiYer,
                CariEhliyet_VerilisTarihi = model.CariEhliyet_VerilisTarihi,
                EhliyetSinif_ID = model.EhliyetSinif_ID,
                KanGrubu_ID = model.KanGrubu_ID,
            };
            db.CariEhliyet.Add(cariEhliyet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Cari.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            CariEhliyet cariEhliyet = db.CariEhliyet.First(x => x.Cari_ID == cari.Cari_ID);
            CariViewModel model = new CariViewModel
            {
                Cari_CreateDate = cari.Cari_CreateDate,
                CariSehir_ID = cari.CariSehir_ID,
                Cari_Adres1 = cari.Cari_Adres1,
                Cari_Adres2 = cari.Cari_Adres2,
                Cari_AdSoyad = cari.Cari_AdSoyad,
                Cari_Cinsiyet = cari.Cari_Cinsiyet,
                Cari_DogumTarihi = cari.Cari_DogumTarihi,
                Cari_EpostaAdresi = cari.Cari_EpostaAdresi,
                Cari_IDNumber = cari.Cari_IDNumber,
                Cari_LokalTelefon = cari.Cari_LokalTelefon,
                Cari_MobilTelefon = cari.Cari_MobilTelefon,
                Cari_UyrukID = cari.Cari_UyrukID,
                CariEhliyet_DogumYeri = cariEhliyet.CariEhliyet_DogumYeri,
                CariEhliyet_EhliyetNumarasi = cariEhliyet.CariEhliyet_EhliyetNumarasi,
                CariEhliyet_GecerlilikTarihi = cariEhliyet.CariEhliyet_GecerlilikTarihi,
                CariEhliyet_Status = (int)DBStatus.Active,
                CariEhliyet_VerildigiYer = cariEhliyet.CariEhliyet_VerildigiYer,
                CariEhliyet_VerilisTarihi = cariEhliyet.CariEhliyet_VerilisTarihi,
                EhliyetSinif_ID = cariEhliyet.EhliyetSinif_ID,
                KanGrubu_ID = cariEhliyet.KanGrubu_ID,
                Cari_Tipi = cari.Cari_Tipi,
                Cari_VergiNo = cari.Cari_VergiNo,
                Cari_VergiDairesi = cari.Cari_VergiDairesi
            };
            ViewBag.EhliyetSinif = db.EhliyetSinif.Find(cariEhliyet.EhliyetSinif_ID).EhliyetSinif_Adi;
            ViewBag.KanGrubu = db.KanGrubu.Find(cariEhliyet.KanGrubu_ID).KanGrubu_Adi;
            ViewBag.Cari_Uyruk = db.CariUyruk.Find(cari.Cari_UyrukID).CariUyruk_Adi;
            ViewBag.CariSehir = db.CariSehir.Find(cari.CariSehir_ID).CariSehir_Adi;


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CariViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Cari cari = db.Cari.Find(id);
                if (cari == null)
                {
                    return HttpNotFound();
                }
                CariEhliyet cariEhliyet = db.CariEhliyet.First(x => x.Cari_ID == cari.Cari_ID);

                cari.CariSehir_ID = model.CariSehir_ID;
                cari.Cari_Adres1 = model.Cari_Adres1;
                cari.Cari_Adres2 = model.Cari_Adres2;
                cari.Cari_AdSoyad = model.Cari_AdSoyad;
                cari.Cari_Cinsiyet = model.Cari_Cinsiyet;
                cari.Cari_DogumTarihi = model.Cari_DogumTarihi;
                cari.Cari_EpostaAdresi = model.Cari_EpostaAdresi;
                cari.Cari_IDNumber = model.Cari_IDNumber;
                cari.Cari_LokalTelefon = model.Cari_LokalTelefon;
                cari.Cari_MobilTelefon = model.Cari_MobilTelefon;
                cari.Cari_UyrukID = model.Cari_UyrukID;

                cari.Cari_Tipi = (int)model.Cari_Tipi;
                cari.Cari_VergiNo = model.Cari_VergiNo;
                cari.Cari_VergiDairesi = model.Cari_VergiDairesi;

                cariEhliyet.Cari_ID = cari.Cari_ID;
                cariEhliyet.CariEhliyet_DogumYeri = model.CariEhliyet_DogumYeri;
                cariEhliyet.CariEhliyet_EhliyetNumarasi = model.CariEhliyet_EhliyetNumarasi;
                cariEhliyet.CariEhliyet_GecerlilikTarihi = model.CariEhliyet_GecerlilikTarihi;
                cariEhliyet.CariEhliyet_Status = (int)DBStatus.Active;
                cariEhliyet.CariEhliyet_VerildigiYer = model.CariEhliyet_VerildigiYer;
                cariEhliyet.CariEhliyet_VerilisTarihi = model.CariEhliyet_VerilisTarihi;
                cariEhliyet.EhliyetSinif_ID = model.EhliyetSinif_ID;
                cariEhliyet.KanGrubu_ID = model.KanGrubu_ID;


                db.Entry(cari).State = EntityState.Modified;
                db.Entry(cariEhliyet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EhliyetSinif = db.EhliyetSinif.Find(model.EhliyetSinif_ID).EhliyetSinif_Adi;
            ViewBag.KanGrubu = db.KanGrubu.Find(model.KanGrubu_ID).KanGrubu_Adi;
            ViewBag.Cari_Uyruk = db.CariUyruk.Find(model.Cari_UyrukID).CariUyruk_Adi;
            ViewBag.CariSehir = db.CariSehir.Find(model.CariSehir_ID).CariSehir_Adi;
            return View(model);
        }

        // GET: Cari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Cari.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            cari.Cari_Status = (int)DBStatus.Deleted;
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
