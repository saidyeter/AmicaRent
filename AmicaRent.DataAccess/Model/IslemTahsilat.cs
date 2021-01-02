using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class IslemTahsilat
    {
        [Key]
        public int IslemTahsilat_ID { get; set; }
        public int? Islem_ID { get; set; }
        public DateTime? IslemTahsilat_Tarih { get; set; }
        public string IslemTahsilat_Aciklama { get; set; }
        public int? OdemeTipi_ID { get; set; }
        public double? IslemTahsilat_Tutar { get; set; }
        public DateTime? IslemTahsilat_CreateDate { get; set; }
        public int IslemTahsilat_Status { get; set; }
    }
}
