using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class AracGrup
    {
        [Key]
        public int AracGrup_ID { get; set; }
        public string AracGrup_Adi { get; set; }
        public int AracGrup_Status { get; set; }
        public DateTime? AracGrup_CreateDate { get; set; }
    }
}
