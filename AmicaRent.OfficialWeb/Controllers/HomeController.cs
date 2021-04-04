using AmicaRent.DataAccess;
using AmicaRent.OfficialWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AmicaRent.OfficialWeb.Controllers
{
    public class HomeController : Controller
    {

        public AmicaRentDBContext db = new AmicaRentDBContext(ConfigurationManager.ConnectionStrings["AmicaRentConnectionString"].ConnectionString);
        public ActionResult Index()
        {
            return RedirectToAction("Anasayfa");
        }

        [Route("anasayfa")]
        public ActionResult Anasayfa()
        {
            ViewBag.Lokasyonlar = db.Lokasyon.ToList();
            return View();
        }

        [Route("hakkinda")]
        public ActionResult Hakkinda()
        {
            return View();
        }

        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }

        [Route("araclistesi")]
        public ActionResult AracListesi()
        {
            var res = getAraclist(null);
            ViewBag.Lokasyonlar = db.Lokasyon.ToList();
            AracFiltreViewModel model = new AracFiltreViewModel
            {
                aracList = res
            };
            return View(model);
        }


        [HttpPost]
        [Route("araclistesi")]
        public ActionResult AracListesi(AracFiltreViewModel model)
        {
            var res = getAraclist(model);
            ViewBag.Lokasyonlar = db.Lokasyon.ToList();
            model.aracList = res;
            return View(model);
        }


        [Route("rezervasyonyap")]
        public ActionResult RezervasyonYap(string o)
        {
            var options = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(o));
            //a=${aracId}&al=${alisLokasyon}&dl=${donusLokasyon}&ag=${alisGun}&as=${alisSaat}&dg=${donusGun}&ds=${donusSaat}`;

            Uri myUri = new Uri("http://www.example.com?" + options);
            var urlParams = HttpUtility.ParseQueryString(myUri.Query);

            int a = Convert.ToInt32(urlParams.Get("a"));
            int al = Convert.ToInt32(urlParams.Get("al"));
            int dl = Convert.ToInt32(urlParams.Get("dl"));
            DateTime ag = Convert.ToDateTime(urlParams.Get("ag"));
            TimeSpan @as = TimeSpan.Parse(urlParams.Get("as"));
            DateTime dg = Convert.ToDateTime(urlParams.Get("dg"));
            TimeSpan ds = TimeSpan.Parse(urlParams.Get("ds"));

            RezervasyonOnKayit model = new RezervasyonOnKayit
            {
                RezervasyonOnKayit_AracID = a,
                RezervasyonOnKayit_AlisLokasyonID = al,
                RezervasyonOnKayit_TeslimLokasyonID = dl,
                RezervasyonOnKayit_AlisTarihi = ag,
                RezervasyonOnKayit_AlisSaati = @as,
                RezervasyonOnKayit_TeslimTarihi = dg,
                RezervasyonOnKayit_TeslimSaati = ds,
            };
            return View(model);
        }


        [HttpPost]
        [Route("rezervasyonyap")]
        public ActionResult RezervasyonYap(RezervasyonOnKayit model)
        {
            if (string.IsNullOrEmpty(model.RezervasyonOnKayit_Ad) ||
                string.IsNullOrEmpty(model.RezervasyonOnKayit_Soyad) ||
                string.IsNullOrEmpty(model.RezervasyonOnKayit_telefon) ||
                string.IsNullOrEmpty(model.RezervasyonOnKayit_email))
            {
                ViewBag.Error = "Tüm alanlar dolu olmalıdır";
                return View(model);
            }

            db.RezervasyonOnKayit.Add(model);
            db.SaveChanges();

            SendMail(model);

            return RedirectToAction("rezervasyonyapildi");
        }

        [Route("rezervasyonyapildi")]
        public ActionResult RezervasyonYapildi()
        {
            return View();
        }


        private void SendMail(RezervasyonOnKayit model)
        {
            string mailTo = ConfigurationManager.AppSettings["ReceiverMail"];
            string mailSubject = "Yeni Rezervasyon Talebi";
            string mailBody = $@"
Sayın ilgili,
Yeni bir rezervasyon ön kaydı yapılmıştır. 
Yönetici panelinde, sol menüden İşlem > Rezervasyon Ön Kayıt Listesi sayfasına giderek inceleyebilirsiniz.
Rezervasyon yapan kişinin bilgileri aşağıdaki gibidir. 
Adı: {model.RezervasyonOnKayit_Ad}
Soyadı: {model.RezervasyonOnKayit_Soyad}
Email: {model.RezervasyonOnKayit_email}
Telefon: {model.RezervasyonOnKayit_telefon}
";
            SendMail(mailTo, mailSubject, mailBody);
        }

        public void SendMail(string mailTo, string mailSubject, string mailBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string smtpServerAddress = ConfigurationManager.AppSettings["SenderSmtpServerAddress"];
                SmtpClient SmtpServer = new SmtpClient(smtpServerAddress);
                string mailFrom = ConfigurationManager.AppSettings["SenderSmtpMail"];
                string sender = ConfigurationManager.AppSettings["SenderSmtpName"];
                mail.From = new MailAddress(mailFrom, sender);
                mail.To.Add(mailTo);
                mail.Subject = mailSubject;
                mail.Body = mailBody;

                int port = Convert.ToInt32(ConfigurationManager.AppSettings["SenderSmtpPort"]);
                SmtpServer.Port = port;
                string username = ConfigurationManager.AppSettings["SenderSmtpUserName"];
                string password = ConfigurationManager.AppSettings["SenderSmtpUserPassword"];
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                bool sslActive = Convert.ToBoolean(ConfigurationManager.AppSettings["SenderSmtpSSLActive"]);
                SmtpServer.EnableSsl = sslActive;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        List<AracViewModel> getAraclist(AracFiltreViewModel model)
        {

            if (model is null)
            {
                var res = (from arac in db.viewAracList
                           where arac.AracKiralamaDurumu == 0
                           select new AracViewModel
                           {
                               Arac_ID = arac.Arac_ID,
                               Base64Resim = "data:image/png;base64,",
                               KM = (int)arac.AracGuncelKM,
                               MarkaModel = arac.AracMarka_Adi + " " + arac.AracModel_Adi,
                               VitesTuru = arac.VitesTipi,
                               YakitTuru = arac.AracYakitTuru_Adi,
                               Yil = arac.Arac_Yil

                           }).Take(5).ToList();

                fillImages(res);
                return res;
            }
            else
            {

                var res = (from arac in db.viewAracList
                           where arac.AracKiralamaDurumu == 0 && arac.Lokasyon_ID == model.alisLokasyon
                           select new AracViewModel
                           {
                               Arac_ID = arac.Arac_ID,
                               Base64Resim = "data:image/png;base64,",
                               KM = (int)arac.AracGuncelKM,
                               MarkaModel = arac.AracMarka_Adi + " " + arac.AracModel_Adi,
                               VitesTuru = arac.VitesTipi,
                               YakitTuru = arac.AracYakitTuru_Adi,
                               Yil = arac.Arac_Yil

                           }).Take(5).ToList();

                fillImages(res);
                return res;

            }
        }

        private void fillImages(List<AracViewModel> model)
        {
            model.ForEach(x =>
            {
                var aracfile = db.AracFile.FirstOrDefault(y => y.Arac_ID == x.Arac_ID);
                if (aracfile is null)
                {
                    x.Base64Resim += emptyImg;
                }
                else
                {
                    var file = db.SysFile.FirstOrDefault(y => y.Id == aracfile.SysFile_ID);
                    if (file is null)
                    {
                        x.Base64Resim += emptyImg;

                    }
                    else
                    {
                        x.Base64Resim += file.File_Content;
                    }
                }
            });
        }

        const string emptyImg = @"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";
    }
}