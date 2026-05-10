using Firma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data
{
    /// <summary>
    /// Główny kontekst bazy danych Entity Framework Core.
    /// Odpowiada za komunikację aplikacji z bazą danych.
    /// </summary>
    public class FirmaDbContext : DbContext
    {
        public FirmaDbContext(DbContextOptions<FirmaDbContext> options) : base(options)
        { }

        // DbSet reprezentuje tabelę w bazie danych
        public DbSet<Pracownik> Pracownicy => Set<Pracownik>();
        public DbSet<Dzial> Dzialy => Set<Dzial>();
        public DbSet<Stanowisko> Stanowiska => Set<Stanowisko>();
        public DbSet<Klient> Klienci => Set<Klient>();
        public DbSet<Projekt> Projekty => Set<Projekt>();
        public DbSet<Zadanie> Zadania => Set<Zadanie>();
        public DbSet<Sprzet> Sprzet => Set<Sprzet>();
        public DbSet<Urlop> Urlopy => Set<Urlop>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Tutaj można dodawać zaawansowane konfiguracje tabel (klucze obce, indeksy, relacje itp.)
        }
    }
}