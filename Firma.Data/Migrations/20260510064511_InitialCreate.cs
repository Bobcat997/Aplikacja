using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dzialy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImieKontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazwiskoKontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stanowiska",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PensjaMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PensjaMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanowiska", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRozpoczecia = table.Column<DateOnly>(type: "date", nullable: false),
                    DataZakonczenia = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    KlientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekty_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataZatrudnienia = table.Column<DateOnly>(type: "date", nullable: false),
                    DataZwolnienia = table.Column<DateOnly>(type: "date", nullable: true),
                    DzialId = table.Column<int>(type: "int", nullable: true),
                    StanowiskoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Dzialy_DzialId",
                        column: x => x.DzialId,
                        principalTable: "Dzialy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pracownicy_Stanowiska_StanowiskoId",
                        column: x => x.StanowiskoId,
                        principalTable: "Stanowiska",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sprzet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumerSeryjny = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataZakupu = table.Column<DateOnly>(type: "date", nullable: false),
                    Wartosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprzet_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Urlopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDo = table.Column<DateOnly>(type: "date", nullable: false),
                    Typ = table.Column<int>(type: "int", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracownikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urlopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urlopy_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priorytet = table.Column<int>(type: "int", nullable: false),
                    TerminRealizacji = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjektId = table.Column<int>(type: "int", nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadania_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zadania_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_DzialId",
                table: "Pracownicy",
                column: "DzialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_StanowiskoId",
                table: "Pracownicy",
                column: "StanowiskoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_KlientId",
                table: "Projekty",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzet_PracownikId",
                table: "Sprzet",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Urlopy_PracownikId",
                table: "Urlopy",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_PracownikId",
                table: "Zadania",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_ProjektId",
                table: "Zadania",
                column: "ProjektId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sprzet");

            migrationBuilder.DropTable(
                name: "Urlopy");

            migrationBuilder.DropTable(
                name: "Zadania");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Projekty");

            migrationBuilder.DropTable(
                name: "Dzialy");

            migrationBuilder.DropTable(
                name: "Stanowiska");

            migrationBuilder.DropTable(
                name: "Klienci");
        }
    }
}
