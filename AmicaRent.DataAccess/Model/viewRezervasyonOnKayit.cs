using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class viewRezervasyonOnKayit
    {
        [Key]
        public int RezervasyonOnKayit_ID { get; set; }

        public string Ad_Soyad { get; set; }

        public string Email { get; set; }

        public string AlisTarihi { get; set; }

        public string Telefon { get; set; }

        public string TeslimTarihi { get; set; }

        public string TeslimSaati { get; set; }

        public string AlisSaati { get; set; }

        public string Plaka { get; set; }

        public string RezervasyonOnKayit_Not { get; set; }

        public string AlisLokasyonu { get; set; }

        public string TeslimLokasyonu { get; set; }

        public string Durum { get; set; }

    }


}
