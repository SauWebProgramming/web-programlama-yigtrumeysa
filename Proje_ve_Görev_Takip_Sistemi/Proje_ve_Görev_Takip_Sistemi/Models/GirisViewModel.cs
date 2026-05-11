using System.ComponentModel.DataAnnotations;

namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}
