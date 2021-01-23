using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class viewAracKredi
    {
        [Key]
        public int AracKredi_ID { get; set; }

        public string OdemeTarihi { get; set; }

        public int AracKredi_KrediTutar { get; set; }

        public string Banka_Adi { get; set; }

        public string AracPlakaNo { get; set; }

        public string AracMarka_Adi { get; set; }

        public string AracModel_Adi { get; set; }

        public bool AracKredi_Odendi { get; set; }

        public DateTime AracKredi_OdemeTarihi { get; set; }

    }
}
