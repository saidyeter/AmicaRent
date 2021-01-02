using System.ComponentModel.DataAnnotations;

namespace AmicaRent.DataAccess
{

    public partial class KullaniciRolTanimlari
    {
        [Key]
        public int Rol_ID { get; set; }
        public string Rol_Adi { get; set; }
        public string Rol_Aciklama { get; set; }
        public int Rol_Kategori { get; set; }
    }
}
