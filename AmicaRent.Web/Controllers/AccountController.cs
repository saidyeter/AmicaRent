using AmicaRent.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : RootController
    {
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        [HttpGet]
        public ActionResult LogOff()
        {

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                          DefaultAuthenticationTypes.ExternalCookie);
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public string OneWayEncrypt(string plainText)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainText)));
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

            var parola = OneWayEncrypt(model.Kullanici_Sifre);
            Kullanici user = db.Kullanici
                .Where(u =>
                    u.Kullanici_Adi == model.Kullanici_Adi &&
                    u.Kullanici_Sifre == parola)
                .FirstOrDefault();

            if (user != null)
            {

                user.Kullanici_SonGirisZamani = DateTime.Now;
                db.SaveChanges();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Kullanici_ID.ToString()),
                    new Claim(ClaimTypes.Name, user.Kullanici_Adi)
                };

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                AuthenticationManager.SignIn(new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = false,//rememberme
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(15)
                }, identity);

                if (string.IsNullOrEmpty(returnUrl))
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
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