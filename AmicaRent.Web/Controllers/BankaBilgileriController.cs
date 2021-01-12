using AmicaRent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BankaBilgileriController : RootController
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

                var data = from bankaBilgileri in db.BankaBilgileri
                           join banka in db.Banka
                           on bankaBilgileri.BankaBilgileri_BankaID equals banka.Banka_ID
                           select new
                           {
                               bankaBilgileri.BankaBilgileri_ID,
                               bankaBilgileri.BankaBilgileri_HesapSahibi,
                               bankaBilgileri.BankaBilgileri_IBAN,
                               banka.Banka_Adi
                           };

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.Banka_Adi.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult Create()
        {
            ViewBag.BankaList = db.Banka.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankaBilgileri bankaBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.BankaBilgileri.Add(bankaBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankaList = db.Banka.ToList();
            return View(bankaBilgileri);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankaBilgileri bankaBilgileri = db.BankaBilgileri.Find(id);
            if (bankaBilgileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankaList = db.Banka.ToList();
            return View(bankaBilgileri);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankaBilgileri bankaBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankaBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankaList = db.Banka.ToList();
            return View(bankaBilgileri);
        }

        // GET: AracMarka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankaBilgileri bankaBilgileri = db.BankaBilgileri.Find(id);
            if (bankaBilgileri == null)
            {
                return HttpNotFound();
            }
            db.BankaBilgileri.Remove(bankaBilgileri);
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