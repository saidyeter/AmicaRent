using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebApplication.DataAccess;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Kullanici user = db.Kullanici
                .Where(u =>
                    u.Kullanici_Adi == model.Kullanici_Adi &&
                    u.Kullanici_Sifre == model.Kullanici_Sifre)
                .FirstOrDefault();

            if (user != null)
            {
                Session["UserName"] = user.Kullanici_Adi;
                Session["UserId"] = user.Kullanici_ID;
                user.Kullanici_SonGirisZamani = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Şifreler Eşleşmiyor.");
                return View(model);
            }
            var Kullanici_ID = Convert.ToInt32(Session["UserId"]);

            Kullanici user = db.Kullanici.Where(u => u.Kullanici_ID == Kullanici_ID && u.Kullanici_Sifre == model.OldPassword).FirstOrDefault();

            if (user != null)
            {
                user.Kullanici_Sifre = model.NewPassword;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Mevcut Şifre Hatalı");
                return View(model);
            }
        }

    }
}