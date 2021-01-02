using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class CariUyruk
    {
        [Key]
        public int CariUyruk_ID { get; set; }
        public string CariUyruk_Adi { get; set; }
        public int CariUyruk_Status { get; set; }
        public DateTime? CariUyruk_CreateDate { get; set; }
    }
}
