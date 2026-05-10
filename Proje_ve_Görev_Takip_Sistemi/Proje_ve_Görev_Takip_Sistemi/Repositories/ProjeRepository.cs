using Microsoft.EntityFrameworkCore;
using Proje_ve_Görev_Takip_Sistemi.Data;
using Proje_ve_Görev_Takip_Sistemi.Models;

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
            // Projeleri getirirken içindeki görevleri de dahil ediyoruz (Eager Loading)
            return _context.Projeler.Include(p => p.Gorevler).ToList();
        }

        public Proje GetirById(int id)
        {
            return _context.Projeler.Include(p => p.Gorevler).FirstOrDefault(p => p.Id == id);
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
            var proje = GetirById(id);
            if (proje != null)
            {
                _context.Projeler.Remove(proje);
                _context.SaveChanges();
            }
        }
    }
}