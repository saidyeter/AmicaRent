using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class CariSehir
    {
        [Key]
        public int CariSehir_ID { get; set; }
        public string CariSehir_Adi { get; set; }
        public int CariSehir_Status { get; set; }
        public DateTime? CariSehir_CreateDate { get; set; }
    }
}
