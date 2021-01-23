using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class KasaIslem
    {
        [Key]
        public int KasaIslem_ID { get; set; }
        public DateTime KasaIslem_Tarih { get; set; }
        public string KasaIslem_Aciklama { get; set; }
        public int OdemeTipi_ID { get; set; }
        public int KasaIslem_Tipi { get; set; }
        public double? KasaIslem_Tutar { get; set; }
        public DateTime? KasaIslem_CreateDate { get; set; }
    }
}
