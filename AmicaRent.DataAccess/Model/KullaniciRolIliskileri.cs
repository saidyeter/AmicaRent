using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class KullaniciRolIliskileri
    {
        [Key]
        public int RolIliski_ID { get; set; }
        public int Rol_ID { get; set; }
        public int Kullanici_ID { get; set; }
    }
}
