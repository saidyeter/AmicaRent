using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class LoginViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kullanıcı Adı")]
        public string Kullanici_Adi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Kullanici_Sifre { get; set; }
    }
}
