using Proje_ve_Görev_Takip_Sistemi.Models;
using System.Collections.Generic;

namespace Proje_ve_Görev_Takip_Sistemi.Repositories
{
    public interface IProjeRepository
    {
        IEnumerable<Proje> TumProjeleriGetir();
        Proje ProjeGetir(int id);
        void Ekle(Proje proje);
        void Guncelle(Proje proje);
        void Sil(int id);
    }
}