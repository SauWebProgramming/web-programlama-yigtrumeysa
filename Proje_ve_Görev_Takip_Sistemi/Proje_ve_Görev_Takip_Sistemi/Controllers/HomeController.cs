using Microsoft.AspNetCore.Mvc;
using Proje_ve_Görev_Takip_Sistemi.Repositories;

namespace Proje_ve_Görev_Takip_Sistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjeRepository _projeRepository;
        private readonly IGorevRepository _gorevRepository;

        public HomeController(IProjeRepository projeRepository, IGorevRepository gorevRepository)
        {
            _projeRepository = projeRepository;
            _gorevRepository = gorevRepository;
        }

        public IActionResult Index()
        {
            // Veritabanındaki kayıt sayılarını alıp önyüze gönderiyoruz
            ViewBag.ProjeSayisi = _projeRepository.TumProjeleriGetir().Count();
            ViewBag.GorevSayisi = _gorevRepository.TumGorevleriGetir().Count();
            return View();
        }
    }
}