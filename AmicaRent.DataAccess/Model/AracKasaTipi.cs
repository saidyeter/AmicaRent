using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class AracKasaTipi
    {
        [Key]
        public int AracKasaTipi_ID { get; set; }
        public string AracKasaTipi_Adi { get; set; }
        public int AracKasaTipi_Status { get; set; }
        public DateTime? AracKasaTipi_CreateDate { get; set; }
    }
}
