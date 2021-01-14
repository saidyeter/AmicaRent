using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class HireViewModel
    {
        public int Islem_Tipi { get; set; } = 1;

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Ödeme Tipi")]
        public int? OdemeTipi_ID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Tahsilat Açıklama")]
        public string Tahsilat_Aciklama { get; set; }

        [Required(ErrorMessage = "{0} Gerekli")]
        [Display(Name = "Tahsil Edilen Ücret")]
        public double? Islem_TahsilEdilen { get; set; }

    }
}