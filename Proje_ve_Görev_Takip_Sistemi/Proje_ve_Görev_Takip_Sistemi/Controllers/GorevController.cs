using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje_ve_Görev_Takip_Sistemi.Models;
using Proje_ve_Görev_Takip_Sistemi.Repositories;
using Proje_ve_Görev_Takip_Sistemi.Data; // Veritabanı bağlamı (DbContext) için eklendi
using System.Threading.Tasks; // Asenkron işlemler (async/await) için eklendi

namespace Proje_ve_Görev_Takip_Sistemi.Controllers
{
    public class GorevController : Controller
    {
        private readonly IGorevRepository _gorevRepository;
        private readonly IProjeRepository _projeRepository;
        private readonly ApplicationDbContext _context; // Anlık durum güncellemesi için eklendi

        // Constructor (Yapıcı Metot) güncellendi: _context eklendi
        public GorevController(IGorevRepository gorevRepository, IProjeRepository projeRepository, ApplicationDbContext context)
        {
            _gorevRepository = gorevRepository;
            _projeRepository = projeRepository;
            _context = context;
        }

        // 1. Tüm Görevleri Listeleme Sayfası
        public IActionResult Index()
        {
            var gorevler = _gorevRepository.TumGorevleriGetir();
            return View(gorevler);
        }

        // 2. Yeni Görev Ekleme Sayfası (Kullanıcıya Formu Gösterir)
        [HttpGet]
        public IActionResult Create()
        {
            // ViewBag ile veritabanındaki projeleri çekip formdaki Dropdown (Seçim) kutusuna gönderiyoruz
            ViewBag.Projeler = new SelectList(_projeRepository.TumProjeleriGetir(), "Id", "Ad");
            return View();
        }

        // 3. Görevi Veritabanına Kaydetme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gorev gorev)
        {
            gorev.Proje = null;

            ModelState.Remove("Id");
            ModelState.Remove("OlusturulmaTarihi");
            ModelState.Remove("Proje");

            if (ModelState.IsValid)
            {
                gorev.OlusturulmaTarihi = DateTime.Now;
                _gorevRepository.Ekle(gorev);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Projeler = new SelectList(_projeRepository.TumProjeleriGetir(), "Id", "Ad", gorev.ProjeId);
            return View(gorev);
        }

        // 4. Görev Durumunu Güncelleme (Arayüzdeki Butonlardan Gelen İstekleri Yakalar)
        [HttpPost]
        public async Task<IActionResult> DurumGuncelle(int id, GorevDurumu yeniDurum)
        {
            // İlgili görevi veritabanından bul
            var gorev = await _context.Gorevler.FindAsync(id);
            if (gorev == null)
            {
                return Json(new { success = false, message = "Görev bulunamadı!" });
            }

            // Durumu değiştir ve veritabanına kaydet
            gorev.Durum = yeniDurum;
            _context.Gorevler.Update(gorev);
            await _context.SaveChangesAsync();

            // İşlem başarılıysa UI (Arayüz) tarafına onay gönder
            return Json(new { success = true });
        }
    }
}