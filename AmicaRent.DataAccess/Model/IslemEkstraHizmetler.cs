using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class IslemEkstraHizmetler
    {
        [Key]
        public int IslemEkstraHizmetler_ID { get; set; }
        public int? Islem_ID { get; set; }
        public int? EkstraHizmetler_ID { get; set; }
        public DateTime? IslemEkstraHizmetler_CreateDate { get; set; }
        public int IslemEkstraHizmetler_Status { get; set; }
    }
}
