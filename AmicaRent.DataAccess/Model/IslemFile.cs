using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public partial class IslemFile
    {
        [Key]
        public int Id { get; set; }
        public int Islem_ID { get; set; }
        public int SysFile_ID { get; set; }
    }
}
