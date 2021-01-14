using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewIslem
    {
        [Key]
        public int Islem_ID { get; set; }

        public string IslemTipim { get; set; }

        public string Cari_AdSoyad { get; set; }

        public string AracGrup_Adi { get; set; }

        public string AracMarka_Adi { get; set; }

        public string AracModel_Adi { get; set; }

        public string Arac_Yil { get; set; }

        public string BaslangicTarihi { get; set; }

        public string BitisTarihi { get; set; }

        public double Islem_GunlukUcret { get; set; }

        public double Islem_TahsilEdilen { get; set; }

        public double Islem_KalanBorc { get; set; }

        public int Islem_Status { get; set; }

        public string AracPlakaNo { get; set; }

        public DateTime Islem_CreateDate { get; set; }

        public int Islem_Tipi { get; set; }

    }
}
