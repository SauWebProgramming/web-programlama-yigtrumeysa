using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Repositories
{
    public interface IGorevRepository
    {
        IEnumerable<Gorev> TumGorevleriGetir();
        void Ekle(Gorev gorev);
    }
}