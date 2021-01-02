using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class Arac
    {
        [Key]
        public int Arac_ID { get; set; }
        public int AracGrup_ID { get; set; }
        public int AracMarka_ID { get; set; }
        public int AracModel_ID { get; set; }
        public string Arac_Yil { get; set; }
        public int AracYakitTuru_ID { get; set; }
        public string Arac_VitesTipi { get; set; }
        public int AracKasaTipi_ID { get; set; }
        public int AracKlimaDurumu { get; set; }
        public string AracPlakaNo { get; set; }
        public double AracGuncelKM { get; set; }
        public string AracMotorNo { get; set; }
        public string AracSaseNo { get; set; }
        public string AracRuhsatSeriNo { get; set; }
        public int Arac_Status { get; set; }
        public int AracRenk_ID { get; set; }
        public int? AracKiralamaDurumu { get; set; }
        public DateTime? Arac_TrafikSigortasiBitisTarihi { get; set; }
        public DateTime? Arac_KaskoBitisTarihi { get; set; }
        public DateTime? Arac_KoltukSigortasiBitisTarihi { get; set; }
        public DateTime? Arac_FenniMuayeneGecerlilikTarihi { get; set; }
    }
}
