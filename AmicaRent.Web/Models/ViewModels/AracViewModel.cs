using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class AracViewModel
    {
        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Araç Grubu")]
        public int? AracGrup_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Marka")]
        public int? AracMarka_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Model")]
        public int? AracModel_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Araç Yıl")]
        [MaxLength(4, ErrorMessage = ("{0} değeri geçerli değildir"))]
        [MinLength(4, ErrorMessage = ("{0} değeri geçerli değildir"))]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} değeri geçerli değildir")]
        public string Arac_Yil { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Yakıt Türü")]
        public int? AracYakitTuru_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Vites Tipi")]
        public int? Arac_VitesTipi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Kasa Tipi")]
        public int? AracKasaTipi_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Klima Durumu")]
        public int? AracKlimaDurumu { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "KM Aşım Ücreti")]
        public int? Arac_AsimUcreti { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Plaka")]
        public string AracPlakaNo { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Güncel KM")]
        public double AracGuncelKM { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Motor No")]
        public string AracMotorNo { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Şase No")]
        public string AracSaseNo { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Ruhsat Seri No")]
        public string AracRuhsatSeriNo { get; set; }


        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Araç Rengi")]
        public int? AracRenk_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Trafik Sigorta Bitiş Tarihi")]
        public DateTime? Arac_TrafikSigortasiBitisTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Kasko Bitiş Tarihi")]
        public DateTime? Arac_KaskoBitisTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Koltuk Sigorta Bitiş Tarihi")]
        public DateTime? Arac_KoltukSigortasiBitisTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Fenni Muayene Geçerlilik Tarihi")]
        public DateTime? Arac_FenniMuayeneGecerlilikTarihi { get; set; }


        public bool Arac_KrediKullanimi { get; set; } = false;

        [Display(Name = "Ödenecek Taksit Sayısı")]
        public int? Arac_KrediTaksitSayisi { get; set; }
        [Display(Name = "Aylık Ödeme Tutarı")]
        public int? Arac_KrediTaksitTutari { get; set; }

        [Display(Name = "Ayın Kaçında Ödeniyor")]
        public int? Arac_KrediTaksitOdemeGunu { get; set; }

        [Display(Name = "Hangi Bankaya Ödeniyor")]
        public int? Arac_KrediBankaID { get; set; }

    }
}