using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class EhliyetSinif
    {
        [Key]
        public int EhliyetSinif_ID { get; set; }
        public string EhliyetSinif_Adi { get; set; }
        public int EhliyetSinif_Status { get; set; }
        public DateTime? EhliyetSinif_CreateDate { get; set; }
    }
}
