using Microsoft.AspNetCore.Identity;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi.Data
{
    public static class DbInitializer
    {
        public static async Task TohumlaAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roller = { "Admin", "Manager", "TeamMember" };
            foreach (var rol in roller)
            {
                if (!await roleManager.RoleExistsAsync(rol))
                    await roleManager.CreateAsync(new IdentityRole(rol));
            }

            var adminEmail = "admin@project.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, AdSoyad = "Sistem Yöneticisi" };
                var sonuc = await userManager.CreateAsync(admin, "Admin123*");
                if (sonuc.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}