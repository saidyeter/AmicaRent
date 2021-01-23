using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class viewKullanici
    {
        [Key]
        public int Kullanici_ID { get; set; }

        public string Kullanici_TamAdi { get; set; }

        public string Kullanici_Adi { get; set; }

        public string Kullanici_Sifre { get; set; }

        public string SonGirisZamani { get; set; }

        public string OlusturmaZamani { get; set; }

    }
}
