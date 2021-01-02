using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class viewAracModel
    {
        [Key]
        public int AracModel_ID { get; set; }
        public int AracMarka_ID { get; set; }
        public string AracMarka_Adi { get; set; }
        public string AracModel_Adi { get; set; }
        public int? AracModel_Status { get; set; }
        public DateTime? AracModel_CreateDate { get; set; }
    }
}
