using Microsoft.AspNetCore.Mvc;
using Proje_ve_Görev_Takip_Sistemi.Models;
using Proje_ve_Görev_Takip_Sistemi.Repositories;

namespace Proje_ve_Görev_Takip_Sistemi.Controllers
{
    public class ProjeController : Controller
    {
        // Veritabanı işlemleri için repository tanımlama
        private readonly IProjeRepository _projeRepository;

        // Constructor - Dependency Injection (Bağımlılık Enjeksiyonu)
        public ProjeController(IProjeRepository projeRepository)
        {
            _projeRepository = projeRepository;
        }

        // Tüm Projeleri Listeleme Sayfası
        public IActionResult Index()
        {
            var projeler = _projeRepository.TumProjeleriGetir();
            return View(projeler);
        }

        // Yeni Proje Ekleme Sayfası (Sadece boş formu açar)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Proje Kaydetme (Kullanıcı butona basınca çalışır)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proje proje)
        {
            // 1. Oluşturulma tarihini o anki sistem saati olarak biz atıyoruz
            proje.OlusturulmaTarihi = DateTime.Now;

            // 2. ModelState güvenlik görevlisine "Bu alanları kontrol etme" diyoruz
            ModelState.Remove("Id");
            ModelState.Remove("OlusturulmaTarihi");

            ModelState.Remove("Id");
            ModelState.Remove("OlusturulmaTarihi");
            // Eğer Proje modelinde Görevler listesi varsa, onu da kontrolden çıkarıyoruz:
            ModelState.Remove("Gorevler");

            if (ModelState.IsValid)
            {
                _projeRepository.Ekle(proje);
                return RedirectToAction(nameof(Index)); // Başarılıysa listeye geri gönderir
            }

            // Eğer hala hata varsa, hatayı formda göstermek için aynı sayfayı açar
            return View(proje);
        }
    }
}