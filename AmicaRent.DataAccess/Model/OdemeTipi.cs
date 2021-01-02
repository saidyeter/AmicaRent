using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class OdemeTipi
    {
        [Key]
        public int OdemeTipi_ID { get; set; }
        public string OdemeTipi_Adi { get; set; }
        public int OdemeTipi_Status { get; set; }
        public DateTime? OdemeTipi_CreateDate { get; set; }
    }
}
