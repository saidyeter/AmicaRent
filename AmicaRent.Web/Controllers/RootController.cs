using AmicaRent.DataAccess;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RootController : Controller
    {
        public AmicaRentDBContext db = new AmicaRentDBContext(ConfigurationManager.ConnectionStrings["AmicaRentConnectionString"].ConnectionString);

        public JsonResult BaseDatatable<TSource>(IQueryable<TSource> queryableData)
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    queryableData = queryableData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                else
                {
                    queryableData = queryableData.OrderBy("Db_InsertTime desc");

                }

                //total number of rows count     
                recordsTotal = queryableData.Count();
                //Paging     
                var data = queryableData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult BaseSelect2List<TSource>(DbSet<TSource> dbSet, Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, Select2Model>> map) where TSource : class
        {
            var list = dbSet.Where(predicate).Select(map).Take(5).ToList();
            return Json(new { items = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AracList(string q = "")
        {
            return BaseSelect2List(
                db.viewAracList,
                x => x.AracKiralamaDurumu == (int)AracDurumu.Bos && (x.AracMarka_Adi.Contains(q) || x.AracModel_Adi.Contains(q) || x.AracPlakaNo.Contains(q)),
                c => new Select2Model { id = c.Arac_ID.ToString(), text = c.AracMarka_Adi + " " + c.AracModel_Adi + " (" + c.AracPlakaNo + ")" });
        }
        public ActionResult CariList(string q = "")
        {
            return BaseSelect2List(db.Cari, x => x.Cari_AdSoyad.Contains(q), c => new Select2Model { id = c.Cari_ID.ToString(), text = c.Cari_AdSoyad });
        }

        public ActionResult ModelList(string q = "", int markaId = 0)
        {
            return BaseSelect2List(db.AracModel, x => x.AracMarka_ID == markaId && x.AracModel_Adi.Contains(q), c => new Select2Model { id = c.AracModel_ID.ToString(), text = c.AracModel_Adi });
        }
        public ActionResult LokasyonList(string q = "")
        {
            return BaseSelect2List(db.Lokasyon, x => x.Lokasyon_Adi.Contains(q), c => new Select2Model { id = c.Lokasyon_ID.ToString(), text = c.Lokasyon_Adi });
        }
        public ActionResult OdemeTipiList(string q = "")
        {
            return BaseSelect2List(db.OdemeTipi, x => x.OdemeTipi_Adi.Contains(q), c => new Select2Model { id = c.OdemeTipi_ID.ToString(), text = c.OdemeTipi_Adi });
        }
        public ActionResult BankaList(string q = "")
        {
            return BaseSelect2List(db.Banka, x => x.Banka_Adi.Contains(q), c => new Select2Model { id = c.Banka_ID.ToString(), text = c.Banka_Adi });
        }
        public ActionResult AracGrupList(string q = "")
        {
            return BaseSelect2List(db.AracGrup, x => x.AracGrup_Adi.Contains(q), c => new Select2Model { id = c.AracGrup_ID.ToString(), text = c.AracGrup_Adi });
        }
        public ActionResult AracMarkaList(string q = "")
        {
            return BaseSelect2List(db.AracMarka, x => x.AracMarka_Adi.Contains(q), c => new Select2Model { id = c.AracMarka_ID.ToString(), text = c.AracMarka_Adi });
        }
        public ActionResult AracRenkList(string q = "")
        {
            return BaseSelect2List(db.AracRenk, x => x.AracRenk_Adi.Contains(q), c => new Select2Model { id = c.AracRenk_ID.ToString(), text = c.AracRenk_Adi });
        }
        public ActionResult AracKasaTipiList(string q = "")
        {
            return BaseSelect2List(db.AracKasaTipi, x => x.AracKasaTipi_Adi.Contains(q), c => new Select2Model { id = c.AracKasaTipi_ID.ToString(), text = c.AracKasaTipi_Adi });
        }
        public ActionResult AracYakitTuruList(string q = "")
        {
            return BaseSelect2List(db.AracYakitTuru, x => x.AracYakitTuru_Adi.Contains(q), c => new Select2Model { id = c.AracYakitTuru_ID.ToString(), text = c.AracYakitTuru_Adi });
        }
        public ActionResult KanGrubuList(string q = "")
        {
            return BaseSelect2List(db.KanGrubu, x => x.KanGrubu_Adi.Contains(q), c => new Select2Model { id = c.KanGrubu_ID.ToString(), text = c.KanGrubu_Adi });
        }

        public ActionResult EhliyetSinifList(string q = "")
        {
            return BaseSelect2List(db.EhliyetSinif, x => x.EhliyetSinif_Adi.Contains(q), c => new Select2Model { id = c.EhliyetSinif_ID.ToString(), text = c.EhliyetSinif_Adi });
        }
        public ActionResult CariSehirList(string q = "")
        {
            return BaseSelect2List(db.CariSehir, x => x.CariSehir_Adi.Contains(q), c => new Select2Model { id = c.CariSehir_ID.ToString(), text = c.CariSehir_Adi });
        }
        public ActionResult CariUyrukList(string q = "")
        {
            return BaseSelect2List(db.CariUyruk, x => x.CariUyruk_Adi.Contains(q), c => new Select2Model { id = c.CariUyruk_ID.ToString(), text = c.CariUyruk_Adi });
        }


        public JsonResult CariDetails(int id)
        {
            var cari = db.Cari.Find(id);
            var ehliyet = db.CariEhliyet.FirstOrDefault(x => x.Cari_ID == cari.Cari_ID);
            var tahsilatlar =
                (from islem in db.Islem
                 join arac in db.Arac
                 on islem.Arac_ID equals arac.Arac_ID
                 where islem.Cari_ID == cari.Cari_ID
                 select new
                 {
                     baslangicTarihi = islem.Islem_BaslangicTarihi,
                     bitisTarihi = islem.Islem_BitisTarihi,
                     //kiralamaSuresi = (islem.Islem_BitisTarihi - islem.Islem_BaslangicTarihi).TotalDays,
                     plaka = arac.AracPlakaNo,
                     kalanBorc = islem.Islem_KalanBorc
                 }).ToList().
                Select(x => new
                {
                    baslangicTarihi = x.baslangicTarihi.ToString("dd MM yyyy"),
                    kiralamaSuresi = (x.bitisTarihi - x.baslangicTarihi).TotalDays,
                    plaka = x.plaka,
                    kalanBorc = x.kalanBorc
                }).ToList();

            return Json(new
            {
                tckn = cari.Cari_IDNumber,
                telno = cari.Cari_MobilTelefon,
                ehliyetno = ehliyet is null ? "yok" : ehliyet.CariEhliyet_EhliyetNumarasi,
                mail = cari.Cari_EpostaAdresi,
                adres = cari.Cari_Adres1 + " " + cari.Cari_Adres2,
                tahsilatlar = tahsilatlar
            });
        }
        public JsonResult AracDetails(int id)
        {
            var arac = db.Arac.Find(id);
            return Json(new
            {
                asimucreti = arac.Arac_AsimUcreti + " TL"
            });
        }


        public int SaveFile(Stream stream, string name)
        {
            var fileBytes = ReadStream(stream);
            return SaveFile(fileBytes, name);
        }
        public int SaveFile(byte[] fileBytes, string name)
        {
            var name_truncated = name;
            if (name.Length > 240) { name_truncated = name.Substring(0, 240); }
            SysFile sysFile = new SysFile
            {
                File_Content = Convert.ToBase64String(fileBytes),
                File_Name = name_truncated,
                File_Size = fileBytes.Length,
                File_InsertDate = DateTime.Now
            };
            db.SysFile.Add(sysFile);
            db.SaveChanges();
            return sysFile.Id;
        }


        public byte[] ReadStream(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
    public class Select2Model
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}