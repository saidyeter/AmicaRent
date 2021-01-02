using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class AracYakitTuru
    {
        [Key]
        public int AracYakitTuru_ID { get; set; }
        public string AracYakitTuru_Adi { get; set; }
        public int AracYakitTuru_Status { get; set; }
        public DateTime AracYakitTuru_CreateDate { get; set; }
    }
}
