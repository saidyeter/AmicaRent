using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class RezervasyonOnKayit
    {
        [Key]
        public int RezervasyonOnKayit_ID { get; set; }

        public string RezervasyonOnKayit_Ad { get; set; }

        public string RezervasyonOnKayit_Soyad { get; set; }

        public string RezervasyonOnKayit_email { get; set; }

        public string RezervasyonOnKayit_telefon { get; set; }

        public DateTime RezervasyonOnKayit_AlisTarihi { get; set; }

        public TimeSpan RezervasyonOnKayit_AlisSaati { get; set; }

        public DateTime RezervasyonOnKayit_TeslimTarihi { get; set; }

        public TimeSpan RezervasyonOnKayit_TeslimSaati { get; set; }

        public int RezervasyonOnKayit_AlisLokasyonID { get; set; }

        public int RezervasyonOnKayit_TeslimLokasyonID { get; set; }

        public int RezervasyonOnKayit_AracID { get; set; }

        public int RezervasyonOnKayit_Durum { get; set; }

        public string RezervasyonOnKayit_Not { get; set; }

    }
}
