using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class ServisFirma
    {
        [Key]
        public int ServisFirma_ID { get; set; }
        public string ServisFirma_Adi { get; set; }
        public string ServisFirma_Adres1 { get; set; }
        public string ServisFirma_Adres2 { get; set; }
        public string ServisFirma_Tel1 { get; set; }
        public string ServisFirma_Tel2 { get; set; }
        public string ServisFirma_Email { get; set; }
        public string ServisFirma_Yetkili { get; set; }
        public DateTime? ServisFirma_CreateDate { get; set; }
        public int ServisFirma_Status { get; set; }
    }
}
