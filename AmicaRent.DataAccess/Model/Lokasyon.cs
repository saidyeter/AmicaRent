using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class Lokasyon
    {
        [Key]
        public int Lokasyon_ID { get; set; }
        public string Lokasyon_Adi { get; set; }
        public int? Lokasyon_Tipi { get; set; }
        public int Lokasyon_Status { get; set; }
        public DateTime? Lokasyon_CreateDate { get; set; }
    }
}
