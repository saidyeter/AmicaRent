using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class CariEhliyet
    {
        [Key]
        public int CariEhliyet_ID { get; set; }
        public int? Cari_ID { get; set; }
        public DateTime? CariEhliyet_VerilisTarihi { get; set; }
        public DateTime? CariEhliyet_GecerlilikTarihi { get; set; }
        public string CariEhliyet_VerildigiYer { get; set; }
        public string CariEhliyet_DogumYeri { get; set; }
        public string CariEhliyet_EhliyetNumarasi { get; set; }
        public int? EhliyetSinif_ID { get; set; }
        public int? KanGrubu_ID { get; set; }
        public int CariEhliyet_Status { get; set; }
    }
}
