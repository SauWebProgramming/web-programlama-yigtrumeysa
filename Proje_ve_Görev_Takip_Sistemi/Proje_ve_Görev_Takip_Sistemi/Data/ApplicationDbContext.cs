using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Veritabanında oluşacak tablolar:
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
    }
}
