using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje_ve_Görev_Takip_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class KimlikVeRollerEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoneticiId",
                table: "Projeler",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AtananKullaniciId",
                table: "Gorevler",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "KayitTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProjeUyeleri",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeUyeleri", x => new { x.ProjeId, x.KullaniciId });
                    table.ForeignKey(
                        name: "FK_ProjeUyeleri_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeUyeleri_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_YoneticiId",
                table: "Projeler",
                column: "YoneticiId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_AtananKullaniciId",
                table: "Gorevler",
                column: "AtananKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeUyeleri_KullaniciId",
                table: "ProjeUyeleri",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_AspNetUsers_AtananKullaniciId",
                table: "Gorevler",
                column: "AtananKullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_AspNetUsers_YoneticiId",
                table: "Projeler",
                column: "YoneticiId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_AspNetUsers_AtananKullaniciId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_AspNetUsers_YoneticiId",
                table: "Projeler");

            migrationBuilder.DropTable(
                name: "ProjeUyeleri");

            migrationBuilder.DropIndex(
                name: "IX_Projeler_YoneticiId",
                table: "Projeler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_AtananKullaniciId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "YoneticiId",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KayitTarihi",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "AtananKullaniciId",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Gorevler",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
