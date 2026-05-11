using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Controllers
{
    public class HesapController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HesapController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris(GirisViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _signInManager.PasswordSignInAsync(model.Email, model.Sifre, model.BeniHatirla, false);

                if (sonuc.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Başarılıysa ana sayfaya git
                }
                ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cikis()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Giris", "Hesap");
        }
    }
}