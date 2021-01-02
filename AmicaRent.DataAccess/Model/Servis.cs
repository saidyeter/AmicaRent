using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public partial class Servis
    {
        [Key]
        public int Servis_ID { get; set; }
        public int? Arac_ID { get; set; }
        public DateTime? Servis_ServisZamani { get; set; }
        public int? ServisFirma_ID { get; set; }
        public string Servis_Notlar { get; set; }
        public double? Servis_Ucreti { get; set; }
        public DateTime? Servis_CreateDate { get; set; }
        public int Servis_Status { get; set; }
    }
}
