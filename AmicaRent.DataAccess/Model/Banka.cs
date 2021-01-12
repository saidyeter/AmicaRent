using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public class Banka
    {
        [Key]
        public int Banka_ID { get; set; }
        public string Banka_Adi { get; set; }
    }
}
