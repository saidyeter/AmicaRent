using System;
using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class KanGrubu
    {
        [Key]
        public int KanGrubu_ID { get; set; }
        public string KanGrubu_Adi { get; set; }
        public int KanGrubu_Status { get; set; }
        public DateTime? KanGrubu_CreateDate { get; set; }
    }
}
