namespace Proje_ve_Görev_Takip_Sistemi.Models
{
    public class ProjeUyesi
    {
        public int ProjeId { get; set; }
        public Proje Proje { get; set; }

        public string KullaniciId { get; set; }
        public ApplicationUser Kullanici { get; set; }
    }
}