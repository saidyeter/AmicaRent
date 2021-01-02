using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class AracMarka
    {
        [Key]
        public int AracMarka_ID { get; set; }
        public string AracMarka_Adi { get; set; }
        public int AracMarka_Status { get; set; }
        public DateTime? AracMarka_CreateDate { get; set; }
    }
}
