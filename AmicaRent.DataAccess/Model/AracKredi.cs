using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class AracKredi
    {
        [Key]
        public int AracKredi_ID { get; set; }
        public int Banka_ID { get; set; }
        public int Arac_ID { get; set; }
        public System.DateTime AracKredi_OdemeTarihi { get; set; }
        public int AracKredi_KrediTutar { get; set; }
        public bool AracKredi_Odendi { get; set; }    }

}
