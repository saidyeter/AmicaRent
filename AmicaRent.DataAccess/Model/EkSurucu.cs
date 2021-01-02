using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class EkSurucu
    {
        [Key]
        public int EkSurucu_ID { get; set; }
        public int? Cari_ID { get; set; }
        public DateTime? EkSurucu_CreateDate { get; set; }
        public int EkSurucu_Status { get; set; }
    }
}
