using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{
    public partial class SysFile
    {
        [Key]
        public int Id { get; set; }
        public string File_Name { get; set; }
        public long File_Size { get; set; }
        public string File_Content { get; set; }
        public System.DateTime File_InsertDate { get; set; }
    }
}
