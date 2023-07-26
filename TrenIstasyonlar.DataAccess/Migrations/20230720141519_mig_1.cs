using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrenIstasyonlar.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Istasyon",
                columns: table => new
                {
                    IstasyonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstasyonAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IstasyonAdres = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    IstasyonKonum = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Istasyon", x => x.IstasyonID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Sefer",
                columns: table => new
                {
                    SeferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalkisIstasyonID = table.Column<int>(type: "int", nullable: true),
                    VarisIstasyonID = table.Column<int>(type: "int", nullable: true),
                    KalkisSaati = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VarisSaati = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sefer", x => x.SeferID);
                    table.ForeignKey(
                        name: "FK_Sefer_Istasyon",
                        column: x => x.KalkisIstasyonID,
                        principalTable: "Istasyon",
                        principalColumn: "IstasyonID");
                    table.ForeignKey(
                        name: "FK_Sefer_Istasyon1",
                        column: x => x.VarisIstasyonID,
                        principalTable: "Istasyon",
                        principalColumn: "IstasyonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_KalkisIstasyonID",
                table: "Sefer",
                column: "KalkisIstasyonID");

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_VarisIstasyonID",
                table: "Sefer",
                column: "VarisIstasyonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Sefer");

            migrationBuilder.DropTable(
                name: "Istasyon");
        }
    }
}
