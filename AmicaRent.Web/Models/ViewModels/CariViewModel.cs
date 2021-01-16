using System;

namespace WebApplication.Models.ViewModels
{
    public class CariViewModel
    { 
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
        public DateTime? CariEhliyet_VerilisTarihi { get; set; }
        public DateTime? CariEhliyet_GecerlilikTarihi { get; set; }
        public string CariEhliyet_VerildigiYer { get; set; }
        public string CariEhliyet_DogumYeri { get; set; }
        public string CariEhliyet_EhliyetNumarasi { get; set; }
        public int? EhliyetSinif_ID { get; set; }
        public int? KanGrubu_ID { get; set; }
        public int CariEhliyet_Status { get; set; }
    }
}