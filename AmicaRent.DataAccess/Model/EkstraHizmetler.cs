using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class EkstraHizmetler
    {
        [Key]
        public int EkstraHizmetler_ID { get; set; }
        public string EkstraHizmetler_Adi { get; set; }
        public double? EkstraHizmetler_Ucreti { get; set; }
        public int EkstraHizmetler_Status { get; set; }
        public DateTime? EkstraHizmetler_CreateDate { get; set; }
    }
}
