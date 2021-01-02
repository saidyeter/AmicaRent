using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewServis
    {
        [Key]
        public int Servis_ID { get; set; }
        public string AracGrup_Adi { get; set; }
        public string AracMarka_Adi { get; set; }
        public string AracModel_Adi { get; set; }
        public string Arac_Yil { get; set; }
        public string AracPlakaNo { get; set; }
        public DateTime? Servis_ServisZamani { get; set; }
        public string ServisFirma_Adi { get; set; }
        public string Servis_Notlar { get; set; }
        public double? Servis_Ucreti { get; set; }
        public int Servis_Status { get; set; }
    }
}
