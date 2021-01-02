using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class Islem
    {
        [Key]
        public int Islem_ID { get; set; }
        public int? Islem_Tipi { get; set; }
        public int? Cari_ID { get; set; }
        public int? Arac_ID { get; set; }
        public DateTime? Islem_BaslangicTarihi { get; set; }
        public DateTime? Islem_BitisTarihi { get; set; }
        public int? Islem_IlkKM { get; set; }
        public int? Islem_SonKM { get; set; }
        public int? Islem_YakitDurumu { get; set; }
        public int? Islem_TeslimatLokasyonID { get; set; }
        public int? Islem_IadeLokasyonID { get; set; }
        public double? Islem_GunlukUcret { get; set; }
        public double? Islem_GunlukKMSiniri { get; set; }
        public double? Islem_ToplamKiralamaUcreti { get; set; }
        public double? Islem_ToplamKMAsimUcreti { get; set; }
        public double? Islem_ToplamEkstraHizmetler { get; set; }
        public double? Islem_ToplamValeHizmetleri { get; set; }
        public double? Islem_ToplamDigerUcretler { get; set; }
        public int? Islem_IskontoOrani { get; set; }
        public double? Islem_TahsilEdilen { get; set; }
        public double? Islem_KalanBorc { get; set; }
        public int Islem_Status { get; set; }
        public DateTime? Islem_CreateDate { get; set; }
    }
}
