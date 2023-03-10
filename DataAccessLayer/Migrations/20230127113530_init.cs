using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminler",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminAd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adminSifre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adminMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adminTur = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminler", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    kullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    kullaniciSifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    kullaniciTc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    kullaniciTel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    kullaniciMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.kullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "menuler",
                columns: table => new
                {
                    menuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuler", x => x.menuId);
                    table.ForeignKey(
                        name: "FK_menuler_menuler_parentId",
                        column: x => x.parentId,
                        principalTable: "menuler",
                        principalColumn: "menuId");
                });

            migrationBuilder.CreateTable(
                name: "salonlar",
                columns: table => new
                {
                    salonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salonAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    kapasite = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salonlar", x => x.salonId);
                });

            migrationBuilder.CreateTable(
                name: "slider",
                columns: table => new
                {
                    sliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sliderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    resimUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slider", x => x.sliderId);
                });

            migrationBuilder.CreateTable(
                name: "turler",
                columns: table => new
                {
                    turId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turler", x => x.turId);
                });

            migrationBuilder.CreateTable(
                name: "etkinlikler",
                columns: table => new
                {
                    etkinlikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etkinlikAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    etkinlikAfis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    silindi = table.Column<bool>(type: "bit", nullable: false),
                    turId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etkinlikler", x => x.etkinlikId);
                    table.ForeignKey(
                        name: "FK_etkinlikler_turler_turId",
                        column: x => x.turId,
                        principalTable: "turler",
                        principalColumn: "turId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seanslar",
                columns: table => new
                {
                    seansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    saat = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false),
                    etkinlikId = table.Column<int>(type: "int", nullable: false),
                    salonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seanslar", x => x.seansId);
                    table.ForeignKey(
                        name: "FK_seanslar_etkinlikler_etkinlikId",
                        column: x => x.etkinlikId,
                        principalTable: "etkinlikler",
                        principalColumn: "etkinlikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seanslar_salonlar_salonId",
                        column: x => x.salonId,
                        principalTable: "salonlar",
                        principalColumn: "salonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "biletler",
                columns: table => new
                {
                    biletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seyirciAd = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    seyirciSoyad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    seyirciTc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    seyirciTur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fiyat = table.Column<double>(type: "float", nullable: false),
                    seriNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    odemeTipi = table.Column<bool>(type: "bit", nullable: false),
                    biletKesimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false),
                    seansId = table.Column<int>(type: "int", nullable: false),
                    kullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biletler", x => x.biletId);
                    table.ForeignKey(
                        name: "FK_biletler_kullanicilar_kullaniciId",
                        column: x => x.kullaniciId,
                        principalTable: "kullanicilar",
                        principalColumn: "kullaniciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_biletler_seanslar_seansId",
                        column: x => x.seansId,
                        principalTable: "seanslar",
                        principalColumn: "seansId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_biletler_kullaniciId",
                table: "biletler",
                column: "kullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_biletler_seansId",
                table: "biletler",
                column: "seansId");

            migrationBuilder.CreateIndex(
                name: "IX_etkinlikler_turId",
                table: "etkinlikler",
                column: "turId");

            migrationBuilder.CreateIndex(
                name: "IX_menuler_parentId",
                table: "menuler",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_seanslar_etkinlikId",
                table: "seanslar",
                column: "etkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_seanslar_salonId",
                table: "seanslar",
                column: "salonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminler");

            migrationBuilder.DropTable(
                name: "biletler");

            migrationBuilder.DropTable(
                name: "menuler");

            migrationBuilder.DropTable(
                name: "slider");

            migrationBuilder.DropTable(
                name: "kullanicilar");

            migrationBuilder.DropTable(
                name: "seanslar");

            migrationBuilder.DropTable(
                name: "etkinlikler");

            migrationBuilder.DropTable(
                name: "salonlar");

            migrationBuilder.DropTable(
                name: "turler");
        }
    }
}
