using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class Cari
    {
        [Key]
        public int Cari_ID { get; set; }
        public string Cari_AdSoyad { get; set; }
        public int? Cari_UyrukID { get; set; }
        public string Cari_IDNumber { get; set; }
        public int? Cari_Cinsiyet { get; set; }
        public DateTime? Cari_DogumTarihi { get; set; }
        public string Cari_EpostaAdresi { get; set; }
        public string Cari_Adres1 { get; set; }
        public string Cari_Adres2 { get; set; }
        public int? CariSehir_ID { get; set; }
        public string Cari_MobilTelefon { get; set; }
        public string Cari_LokalTelefon { get; set; }
        public DateTime? Cari_CreateDate { get; set; }
        public int Cari_Status { get; set; }
    }
}
