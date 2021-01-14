using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class IslemViewModel
    {

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "İşlem Tipi")]
        public int? Islem_Tipi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Ödeme Tipi")]
        public int? OdemeTipi_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Tahsilat Açıklama")]
        public string Tahsilat_Aciklama { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Cari")]
        public int? Cari_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Araç")]
        public int? Arac_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Islem Baslangıç Tarihi")]
        public DateTime? Islem_BaslangicTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Islem Bitiş Tarihi")]
        public DateTime? Islem_BitisTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Alış KM")]
        public int? Islem_IlkKM { get; set; }

        //sonra
        //public int? Islem_SonKM { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Alış Yakıt Durumu")]
        public int? Islem_YakitDurumu { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Alış Lokasyon ")]
        public int? Islem_TeslimatLokasyonID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "İade Lokasyon ")]
        public int? Islem_IadeLokasyonID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Günlük Ücret ")]
        public double? Islem_GunlukUcret { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Günlük KM Sınırı ")]
        public double? Islem_GunlukKMSiniri { get; set; }
        //public double? Islem_ToplamKiralamaUcreti { get; set; }
        //public double? Islem_ToplamKMAsimUcreti { get; set; }
        //public double? Islem_ToplamEkstraHizmetler { get; set; }
        //public double? Islem_ToplamValeHizmetleri { get; set; }
        //public double? Islem_ToplamDigerUcretler { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "İndirim Oranı ")]
        public int? Islem_IskontoOrani { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Tahsil Edilen Ücret")]
        public double? Islem_TahsilEdilen { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Kalan Ücret ")]
        public double? Islem_KalanBorc { get; set; }
        public int Islem_Status { get; set; } = (int)DBStatus.Active;
        public DateTime Islem_CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Ek Sürücü")]
        public int? Islem_EkSurucuCari_ID { get; set; }

    }
}