using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public partial class AracFile
    {
        [Key]
        public int Id { get; set; }
        public int Arac_ID { get; set; }
        public int SysFile_ID { get; set; }
    }
}
