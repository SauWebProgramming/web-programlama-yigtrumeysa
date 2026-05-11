using System.ComponentModel.DataAnnotations;

namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    public class Proje
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Proje adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Proje adı en fazla 100 karakter olabilir.")]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        // Bir projenin birden fazla görevi olabilir
        public virtual ICollection<Gorev> Gorevler { get; set; }

        // ... Mevcut kodlar (Id, Ad, Aciklama vs.) kalsın ...

        // Yeni Eklenenler:
        public string? YoneticiId { get; set; }
        public ApplicationUser? Yonetici { get; set; }
        public ICollection<ProjeUyesi>? ProjeUyeleri { get; set; }
    }
}