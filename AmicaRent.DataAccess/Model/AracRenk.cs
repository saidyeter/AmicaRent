using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class AracRenk
    {
        [Key]
        public int AracRenk_ID { get; set; }
        public string AracRenk_Adi { get; set; }
        public int AracRenk_Status { get; set; }
        public DateTime? AracRenk_CreateDate { get; set; }
    }
}
