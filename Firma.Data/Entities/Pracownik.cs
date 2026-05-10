using Firma.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Reprezentuje pracownika firmy w bazie danych.
    /// </summary>
    public class Pracownik
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(100)]
        public string Imie { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(100)]
        public string Nazwisko { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Telefon { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }

        public DateOnly DataZatrudnienia { get; set; }
        public DateOnly? DataZwolnienia { get; set; }

        // Relacje z innymi tabelami
        public int? DzialId { get; set; }
        public Dzial? Dzial { get; set; }

        public int? StanowiskoId { get; set; }
        public Stanowisko? Stanowisko { get; set; }

        // Nawigacja do powiązanych rekordów
        public ICollection<Urlop> Urlopy { get; set; } = new List<Urlop>();
        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}