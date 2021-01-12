using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class BankaBilgileri
    {
        [Key]
        public int BankaBilgileri_ID { get; set; }
        public string BankaBilgileri_IBAN { get; set; }
        public string BankaBilgileri_SubeKodu { get; set; }
        public string BankaBilgileri_HesapKodu { get; set; }
        public string BankaBilgileri_HesapSahibi { get; set; }
        public int BankaBilgileri_BankaID { get; set; }
    }
}
