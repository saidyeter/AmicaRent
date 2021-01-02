using AmicaRent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class KullaniciController : RootController
    {
        

        // GET: Kullanici
        public ActionResult Index()
        {
            return View(db.Kullanici.Where(x => x.Kullanici_Status == (int)DBStatus.Active).ToList());
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kullanici_ID,Kullanici_TamAdi,Kullanici_Adi,Kullanici_Sifre,Kullanici_SonGirisZamani,Kullanici_Status,Kullanici_CreateDate")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.Kullanici_Status = (int)DBStatus.Active;
                kullanici.Kullanici_CreateDate = DateTime.Now;
                kullanici.Kullanici_SonGirisZamani = DateTime.Now;
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                ViewBag.Message = "Kullanıcı eklendi. Yetkileri aşağıdan seçiniz.";
                return RedirectToAction("ManageRole", new { id = kullanici.Kullanici_ID });
            }

            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kullanici_ID,Kullanici_TamAdi,Kullanici_Adi,Kullanici_Sifre,Kullanici_SonGirisZamani,Kullanici_Status,Kullanici_CreateDate")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            kullanici.Kullanici_Status = (int)DBStatus.Deleted;
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


        [HttpGet]
        public ActionResult ManageRole(int id)
        {
            var roles = db.KullaniciRolTanimlari.ToList();
            var userRoles = db.KullaniciRolIliskileri.Where(x => x.Kullanici_ID == id);

            var roles_userRoles = new List<KeyValuePair<KullaniciRolTanimlari, bool>>();
            foreach (var role in roles)
            {
                if (userRoles.Any(u => u.Rol_ID == role.Rol_ID))
                {
                    roles_userRoles.Add(new KeyValuePair<KullaniciRolTanimlari, bool>(role, true));
                }
                else
                {
                    roles_userRoles.Add(new KeyValuePair<KullaniciRolTanimlari, bool>(role, false));
                }
            }
            ViewBag.CurrentlyRoles = string.Join(",", userRoles.Select(x => x.Rol_ID.ToString()).ToList());
            ViewBag.ManagedUserId = id;
            ViewBag.RoleCategories = roles.Select(x => x.Rol_Kategori).Distinct().ToList();


            return View(roles_userRoles);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageRole(string roles, int ManagedUserId)
        {
            //optimize edilecek
            var currentRoles = db.KullaniciRolIliskileri.Where(x => x.Kullanici_ID == ManagedUserId).ToList();
            foreach (var item in currentRoles)
            {
                db.KullaniciRolIliskileri.Remove(item);
            }

            if (!string.IsNullOrEmpty(roles))
            {
                var roleList = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var role in roleList)
                {
                    db.KullaniciRolIliskileri.Add(new KullaniciRolIliskileri
                    {
                        Kullanici_ID = ManagedUserId,
                        Rol_ID = Convert.ToInt32(role)
                    });
                }
                db.SaveChanges();

            }


            return RedirectToAction("Index");
        }
    }
}
