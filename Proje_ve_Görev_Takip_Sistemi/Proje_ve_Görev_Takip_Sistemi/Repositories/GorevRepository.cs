using Microsoft.EntityFrameworkCore;
using Proje_ve_Görev_Takip_Sistemi.Data;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Repositories
{
    public class GorevRepository : IGorevRepository
    {
        private readonly ApplicationDbContext _context;

        public GorevRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gorev> TumGorevleriGetir()
        {
            return _context.Gorevler.Include(g => g.Proje).ToList();
        }

        public Gorev GetirById(int id)
        {
            return _context.Gorevler.Include(g => g.Proje).FirstOrDefault(g => g.Id == id);
        }

        public void Ekle(Gorev gorev)
        {
            _context.Gorevler.Add(gorev);
            _context.SaveChanges();
        }

        public void Guncelle(Gorev gorev)
        {
            _context.Gorevler.Update(gorev);
            _context.SaveChanges();
        }

        public void Sil(int id)
        {
            var gorev = GetirById(id);
            if (gorev != null)
            {
                _context.Gorevler.Remove(gorev);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Gorev> ProjeyeGoreGetir(int projeId)
        {
            return _context.Gorevler.Where(g => g.ProjeId == projeId).ToList();
        }
    }
}