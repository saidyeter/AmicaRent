using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class viewKasaIslem
    {
        [Key]
        public int KasaIslem_ID { get; set; }

        public string KasaIslem_Aciklama { get; set; }

        public string KasaIslem_Tarih { get; set; }

        public string IslemTipi { get; set; }

        public double KasaIslem_Tutar { get; set; }

        public string OdemeTipi_Adi { get; set; }

    }

}
