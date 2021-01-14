using AmicaRent.DataAccess;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class IslemController : RootController
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

                var data = db.viewIslem.Where(x => x.Islem_Status == (int)DBStatus.Active);

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.Cari_AdSoyad.Contains(searchValue) || m.AracPlakaNo.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// GET: Islem/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var islem = db.viewIslem.SingleOrDefault(x => x.Islem_ID == id);

        //    if (islem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(islem);
        //}

        // GET: Islem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Islem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebApplication.Models.ViewModels.IslemViewModel model, List<HttpPostedFileBase> aracResimleri)
        {
            if (ModelState.IsValid)
            {
                Islem islem = new Islem
                {
                    Arac_ID = model.Arac_ID ?? 0,
                    Cari_ID = model.Cari_ID ?? 0,
                    Islem_BaslangicTarihi = model.Islem_BaslangicTarihi ?? DateTime.Now,
                    Islem_BitisTarihi = model.Islem_BitisTarihi ?? DateTime.Now,
                    Islem_CreateDate = model.Islem_CreateDate,
                    Islem_EkSurucuCari_ID = model.Islem_EkSurucuCari_ID,
                    Islem_GunlukKMSiniri = model.Islem_GunlukKMSiniri ?? 0,
                    Islem_GunlukUcret = model.Islem_GunlukUcret ?? 0,
                    Islem_IadeLokasyonID = model.Islem_IadeLokasyonID ?? 0,
                    Islem_IlkKM = model.Islem_IlkKM ?? 0,
                    Islem_IskontoOrani = model.Islem_IskontoOrani ?? 0,
                    Islem_KalanBorc = model.Islem_KalanBorc ?? 0,
                    Islem_Status = model.Islem_Status,
                    Islem_TahsilEdilen = model.Islem_TahsilEdilen ?? 0,
                    Islem_TeslimatLokasyonID = model.Islem_TeslimatLokasyonID ?? 0,
                    Islem_Tipi = model.Islem_Tipi ?? 0,
                    Islem_YakitDurumu = model.Islem_YakitDurumu ?? 0,
                };
                db.Islem.Add(islem);
                db.SaveChanges();
                IslemTahsilat tahsilat = new IslemTahsilat
                {
                    IslemTahsilat_Aciklama = model.Tahsilat_Aciklama,
                    IslemTahsilat_CreateDate = DateTime.Now,
                    IslemTahsilat_ID = 0,
                    IslemTahsilat_Status = (int)DBStatus.Active,
                    IslemTahsilat_Tarih = DateTime.Now,
                    IslemTahsilat_Tutar = model.Islem_TahsilEdilen ?? 0,
                    Islem_ID = islem.Islem_ID,
                    OdemeTipi_ID = model.OdemeTipi_ID,
                };
                db.IslemTahsilat.Add(tahsilat);
                db.SaveChanges();
                foreach (var item in aracResimleri)
                {
                    if (item != null)
                    {
                        try
                        {
                            var itemId = SaveFile(item.InputStream, item.FileName);
                            IslemFile file = new IslemFile();
                            file.Islem_ID = islem.Islem_ID;
                            file.SysFile_ID = itemId;
                            db.IslemFile.Add(file);
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Done(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";

            ViewBag.IslemId = islem.Islem_ID;
            DoneViewModel model = new DoneViewModel
            {
                Islem_TahsilEdilen = islem.Islem_KalanBorc,
                Tahsilat_Aciklama = "Kiralama tamamlanırken tahsil edildi.",
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Done(DoneViewModel model, int id)
        {
            Islem islem = db.Islem.Find(id);
            if (ModelState.IsValid)
            {
                islem.Islem_TahsilEdilen += model.Islem_TahsilEdilen ?? 0;
                islem.Islem_KalanBorc -= model.Islem_TahsilEdilen ?? 0;
                IslemTahsilat tahsilat = new IslemTahsilat
                {
                    IslemTahsilat_Aciklama = model.Tahsilat_Aciklama,
                    IslemTahsilat_CreateDate = DateTime.Now,
                    IslemTahsilat_ID = 0,
                    IslemTahsilat_Status = (int)DBStatus.Active,
                    IslemTahsilat_Tarih = DateTime.Now,
                    IslemTahsilat_Tutar = model.Islem_TahsilEdilen ?? 0,
                    Islem_ID = islem.Islem_ID,
                    OdemeTipi_ID = model.OdemeTipi_ID,
                };
                db.IslemTahsilat.Add(tahsilat);
                islem.Islem_Tipi = 4;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";

            ViewBag.IslemId = islem.Islem_ID;

            return View(model);
        }
        public ActionResult Hire(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";
            HireViewModel model = new HireViewModel
            {
                Islem_TahsilEdilen = islem.Islem_KalanBorc,
                Tahsilat_Aciklama = "Rezervasyondan Kiralamaya geçerken tahsil edildi.",
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Hire(HireViewModel model, int id)
        {
            Islem islem = db.Islem.Find(id);
            if (ModelState.IsValid)
            {
                islem.Islem_TahsilEdilen += model.Islem_TahsilEdilen ?? 0;
                islem.Islem_KalanBorc -= model.Islem_TahsilEdilen ?? 0;
                IslemTahsilat tahsilat = new IslemTahsilat
                {
                    IslemTahsilat_Aciklama = model.Tahsilat_Aciklama,
                    IslemTahsilat_CreateDate = DateTime.Now,
                    IslemTahsilat_ID = 0,
                    IslemTahsilat_Status = (int)DBStatus.Active,
                    IslemTahsilat_Tarih = DateTime.Now,
                    IslemTahsilat_Tutar = model.Islem_TahsilEdilen ?? 0,
                    Islem_ID = islem.Islem_ID,
                    OdemeTipi_ID = model.OdemeTipi_ID,
                };
                db.IslemTahsilat.Add(tahsilat);
                islem.Islem_Tipi = 3;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";
            return View(model);
        }

        public ActionResult CancelReservation(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";
            CancelViewModel model = new CancelViewModel
            {
                Islem_TahsilEdilen = islem.Islem_TahsilEdilen,
                Tahsilat_Aciklama = "Rezervasyon iptal edilirken iade edildi.",
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CancelReservation(CancelViewModel model, int id)
        {
            Islem islem = db.Islem.Find(id);
            if (ModelState.IsValid)
            {
                islem.Islem_TahsilEdilen += model.Islem_TahsilEdilen ?? 0;
                islem.Islem_KalanBorc -= model.Islem_TahsilEdilen ?? 0;
                IslemTahsilat tahsilat = new IslemTahsilat
                {
                    IslemTahsilat_Aciklama = model.Tahsilat_Aciklama,
                    IslemTahsilat_CreateDate = DateTime.Now,
                    IslemTahsilat_ID = 0,
                    IslemTahsilat_Status = (int)DBStatus.Active,
                    IslemTahsilat_Tarih = DateTime.Now,
                    IslemTahsilat_Tutar = -1 * (model.Islem_TahsilEdilen ?? 0),
                    Islem_ID = islem.Islem_ID,
                    OdemeTipi_ID = model.OdemeTipi_ID,
                };
                db.IslemTahsilat.Add(tahsilat);
                islem.Islem_Tipi = 2;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var cari = db.Cari.Find(islem.Cari_ID);
            ViewBag.CariBilgisi = cari.Cari_AdSoyad;

            var arac = db.viewAracList.First(x => x.Arac_ID == islem.Arac_ID);
            ViewBag.AracBilgisi = arac.AracMarka_Adi + " " + arac.AracModel_Adi + " (" + arac.AracPlakaNo + ")";
            return View(model);
        }



        public ActionResult DownloadReservationImages(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }

            var outputStream = new MemoryStream();

            using (var zip = new ZipFile())
            {
                foreach (var item in db.IslemFile.Where(x => x.Islem_ID == islem.Islem_ID).ToList())
                {
                    var file = db.SysFile.FirstOrDefault(x => x.Id == item.SysFile_ID);
                    if (file is null) { continue; }
                    zip.AddEntry(file.File_Name, Convert.FromBase64String(file.File_Content));
                }
                zip.Save(outputStream);
            }


            outputStream.Position = 0;
            return File(outputStream, "application/zip", islem.Cari_ID + "_" + islem.Arac_ID + ".zip");
        }

        //// GET: Islem/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Islem islem = db.Islem.Find(id);
        //    if (islem == null)
        //    {
        //        return HttpNotFound();
        //    }


        //    List<Cari> cariList = db.Cari.ToList();
        //    ViewBag.CariList = cariList;

        //    Dictionary<int, string> aracList = new Dictionary<int, string>();
        //    foreach (var arac in db.viewAracList.Where(x => x.Arac_Status == (int)DBStatus.Active).ToList())
        //    {
        //        aracList.Add(arac.Arac_ID, arac.AracGrup_Adi + " " + arac.AracMarka_Adi + " " + arac.AracModel_Adi + " " + arac.Arac_Yil);
        //    }
        //    ViewBag.AracList = aracList;

        //    Dictionary<int, string> islemTipi = new Dictionary<int, string>();
        //    islemTipi.Add(1, "Rezervasyon");
        //    islemTipi.Add(2, "Kiralama");
        //    ViewBag.IslemTipi = islemTipi;

        //    return View(islem);
        //}

        //// POST: Islem/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Islem_ID,Islem_Tipi,Cari_ID,Arac_ID,Islem_BaslangicTarihi,Islem_BitisTarihi,Islem_IlkKM,Islem_SonKM,Islem_YakitDurumu,Islem_TeslimatLokasyonID,Islem_IadeLokasyonID,Islem_GunlukUcret,Islem_GunlukKMSiniri,Islem_ToplamKiralamaUcreti,Islem_ToplamKMAsimUcreti,Islem_ToplamEkstraHizmetler,Islem_ToplamValeHizmetleri,Islem_ToplamDigerUcretler,Islem_IskontoOrani,Islem_TahsilEdilen,Islem_KalanBorc,Islem_Status,Islem_CreateDate")] Islem islem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(islem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(islem);
        //}

        // GET: Islem/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Islem islem = db.Islem.Find(id);
        //    if (islem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    islem.Islem_Status = (int)DBStatus.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

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
