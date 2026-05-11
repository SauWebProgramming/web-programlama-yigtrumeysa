using System;

namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    // Enum tanımı sınıfın dışında (ama namespace içinde) durur
    public enum GorevDurumu { Beklemede, Yapiliyor, Tamamlandi }

    public class Gorev
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        // Proje Bağlantısı
        public int ProjeId { get; set; }
        public Proje Proje { get; set; }

        // Görev Durumu ve Atanan Kullanıcı (Rol Sistemi)
        public GorevDurumu Durum { get; set; } = GorevDurumu.Beklemede;

        public string? AtananKullaniciId { get; set; }
        public ApplicationUser? AtananKullanici { get; set; }
    }
}