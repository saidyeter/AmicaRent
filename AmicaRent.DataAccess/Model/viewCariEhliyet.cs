using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewCariEhliyet
    {
        [Key]
        public int CariEhliyet_ID { get; set; }
        public int? Cari_ID { get; set; }
        public string Cari_AdSoyad { get; set; }
        public string VerilisTarihi { get; set; }
        public string GecerlilikTarihi { get; set; }
        public string CariEhliyet_DogumYeri { get; set; }
        public string CariEhliyet_EhliyetNumarasi { get; set; }
        public string EhliyetSinif_Adi { get; set; }
        public string KanGrubu_Adi { get; set; }
        public int CariEhliyet_Status { get; set; }
    }
}
