using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje_ve_Görev_Takip_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class ModelGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Baslik",
                table: "Gorevler",
                newName: "Ad");

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarihi",
                table: "Gorevler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OlusturulmaTarihi",
                table: "Gorevler");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Gorevler",
                newName: "Baslik");
        }
    }
}
