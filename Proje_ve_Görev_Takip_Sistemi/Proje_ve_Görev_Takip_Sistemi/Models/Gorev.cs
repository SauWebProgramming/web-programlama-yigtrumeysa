using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    public enum GorevDurumu
    {
        Beklemede,
        Yapiliyor,
        Tamamlandi
    }

    public class Gorev
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Görev başlığı zorunludur.")]
        [StringLength(200)]
        public string Baslik { get; set; }

        public string Aciklama { get; set; }

        public GorevDurumu Durum { get; set; } = GorevDurumu.Beklemede;

        // Proje ile ilişki (Foreign Key)
        public int ProjeId { get; set; }

        [ForeignKey("ProjeId")]
        public virtual Proje Proje { get; set; }

        // Görevin atandığı kullanıcı (Identity tablosuyla ilişki)
        public string? AtananKullaniciId { get; set; }
    }
}