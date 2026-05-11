using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Data
{
    // DbContext yerine IdentityDbContext<ApplicationUser> yapıyoruz
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<ProjeUyesi> ProjeUyeleri { get; set; } // Yeni eklendi

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ProjeUyesi için Çok-a-Çok (Many-to-Many) ilişkisi
            builder.Entity<ProjeUyesi>()
                .HasKey(pu => new { pu.ProjeId, pu.KullaniciId });
        }
    }
}