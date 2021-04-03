using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewCari
    {
        [Key]
        public int Cari_ID { get; set; }
        public int Cari_Status { get; set; }
        public string Cari_AdSoyad { get; set; }
        public string CariUyruk_Adi { get; set; }
        public string Cari_IDNumber { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime? Cari_DogumTarihi { get; set; }
        public string Cari_EpostaAdresi { get; set; }
        public string Cari_Adres1 { get; set; }
        public string Cari_Adres2 { get; set; }
        public string CariSehir_Adi { get; set; }
        public string Cari_MobilTelefon { get; set; }
        public string Cari_LokalTelefon { get; set; }
        public DateTime? Cari_CreateDate { get; set; }
        public int? CariEhliyet_ID { get; set; }


        public string Tip { get; set; }
        public string Cari_VergiNo { get; set; }
        public string Cari_VergiDairesi { get; set; }
    }
}
