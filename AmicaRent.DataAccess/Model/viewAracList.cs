using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewAracList
    {
        [Key]
        public int Arac_ID { get; set; }
        public int Arac_Status { get; set; }
        public int AracKiralamaDurumu { get; set; }
        public string AracGrup_Adi { get; set; }
        public string AracMarka_Adi { get; set; }
        public string AracModel_Adi { get; set; }
        public string Arac_Yil { get; set; }
        public string AracYakitTuru_Adi { get; set; }
        public string VitesTipi { get; set; }
        public string AracKasaTipi_Adi { get; set; }
        public string KlimaDurumu { get; set; }
        public string AracPlakaNo { get; set; }
        public double AracGuncelKM { get; set; }
        public string AracMotorNo { get; set; }
        public string AracSaseNo { get; set; }
        public string AracRuhsatSeriNo { get; set; }
        public string AracRenk_Adi { get; set; }
        public string KiralamaDurumu { get; set; }
        public DateTime? Arac_TrafikSigortasiBitisTarihi { get; set; }
        public DateTime? Arac_KaskoBitisTarihi { get; set; }
        public DateTime? Arac_KoltukSigortasiBitisTarihi { get; set; }
        public DateTime? Arac_FenniMuayeneGecerlilikTarihi { get; set; }
        public string Lokasyon_Adi { get; set; }
        public int Lokasyon_ID { get; set; }
    }
}
