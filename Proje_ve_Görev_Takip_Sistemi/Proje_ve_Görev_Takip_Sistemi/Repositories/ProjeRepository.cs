using Proje_ve_Görev_Takip_Sistemi.Data;
using Proje_ve_Görev_Takip_Sistemi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proje_ve_Görev_Takip_Sistemi.Repositories
{
    public class ProjeRepository : IProjeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Proje> TumProjeleriGetir()
        {
            // Veritabanındaki tüm projeleri listeler
            return _context.Projeler.ToList();
        }

        public Proje ProjeGetir(int id)
        {
            return _context.Projeler.FirstOrDefault(p => p.Id == id);
        }

        public void Ekle(Proje proje)
        {
            _context.Projeler.Add(proje);
            _context.SaveChanges();
        }

        public void Guncelle(Proje proje)
        {
            _context.Projeler.Update(proje);
            _context.SaveChanges();
        }

        public void Sil(int id)
        {
            var silinecek = _context.Projeler.Find(id);
            if (silinecek != null)
            {
                _context.Projeler.Remove(silinecek);
                _context.SaveChanges();
            }
        }
    }
}