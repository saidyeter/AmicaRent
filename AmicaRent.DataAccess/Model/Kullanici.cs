using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class Kullanici
    {
        [Key]
        public int Kullanici_ID { get; set; }
        public string Kullanici_TamAdi { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Kullanici_Sifre { get; set; }
        public DateTime? Kullanici_SonGirisZamani { get; set; }
        public int Kullanici_Status { get; set; }
        public DateTime? Kullanici_CreateDate { get; set; }
    }
}
