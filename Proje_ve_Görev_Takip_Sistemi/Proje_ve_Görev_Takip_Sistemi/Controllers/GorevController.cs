using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje_ve_Görev_Takip_Sistemi.Models;
using Proje_ve_Görev_Takip_Sistemi.Repositories;

namespace Proje_ve_Görev_Takip_Sistemi.Controllers
{
    public class GorevController : Controller
    {
        private readonly IGorevRepository _gorevRepository;
        private readonly IProjeRepository _projeRepository; // Dropdown'da projeleri listelemek için lazım

        public GorevController(IGorevRepository gorevRepository, IProjeRepository projeRepository)
        {
            _gorevRepository = gorevRepository;
            _projeRepository = projeRepository;
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
    }
}