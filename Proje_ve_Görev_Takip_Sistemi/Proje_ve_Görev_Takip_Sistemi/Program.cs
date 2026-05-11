using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proje_ve_Görev_Takip_Sistemi.Data;
using Proje_ve_Görev_Takip_Sistemi.Repositories;
using Proje_ve_Görev_Takip_Sistemi.Models;

namespace Proje_ve_Görev_Takip_Sistemi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IProjeRepository, ProjeRepository>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Identity Kurulumu
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Hesap/Giris";
                options.AccessDeniedPath = "/Hesap/Yetkisiz";
            });

            // Repository'leri sisteme tanıtma (Dependency Injection)

            builder.Services.AddScoped<IGorevRepository, GorevRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // .Wait() sildik, yerine olması gerektiği gibi await ekledik.
                await Proje_ve_Görev_Takip_Sistemi.Data.DbInitializer.TohumlaAsync(services);
            }

            app.Run();
        }
    }
}
