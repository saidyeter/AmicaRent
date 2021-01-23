using AmicaRent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class KasaIslemController : RootController
    {
        // GET: KasaIslem
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

                var data = db.viewKasaIslem.AsQueryable();


                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.KasaIslem_Aciklama.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create(int? id)
        {
            if (id is null)
            {
                return View();
            }
            Cari cari = db.Cari.Find(id);
            KasaIslem model = new KasaIslem
            {
                KasaIslem_Aciklama = $"{cari.Cari_AdSoyad} adlı müşterinden tahsil edilmiştir."
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(KasaIslem kasaIslem)
        {
            try
            {
                #region Manuel Model Control
                if (kasaIslem.KasaIslem_Tutar == null)
                {
                    ModelState.AddModelError("KasaIslem_Tutar", "Tutar Gerekli.");
                }
                if (string.IsNullOrEmpty(kasaIslem.KasaIslem_Aciklama))
                {
                    ModelState.AddModelError("KasaIslem_Aciklama", "Açıklama eksik olamaz!");
                }
                if (kasaIslem.OdemeTipi_ID == 0)
                {
                    ModelState.AddModelError("OdemeTipi_ID", "Ödeme Tipi Gerekli.");
                }

                if (kasaIslem.KasaIslem_Tipi == 0)
                {
                    ModelState.AddModelError("KasaIslem_Tipi", "İşlem Tipi Gerekli.");
                }
                if (!ModelState.IsValid)
                {
                    return View(kasaIslem);
                }
                #endregion


                var truncated = kasaIslem.KasaIslem_Aciklama;
                if (truncated.Length > 500) { truncated = truncated.Substring(0, 500); }

                kasaIslem.KasaIslem_Aciklama = truncated;
                kasaIslem.KasaIslem_Tarih = DateTime.Now;
                kasaIslem.KasaIslem_CreateDate = DateTime.Now;    
                db.KasaIslem.Add(kasaIslem);            
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
