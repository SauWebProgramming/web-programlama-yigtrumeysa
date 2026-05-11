using Microsoft.AspNetCore.Identity;

namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AdSoyad { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}