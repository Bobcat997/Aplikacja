using Firma.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Pojedyncze zadanie w ramach projektu.
    /// </summary>
    public class Zadanie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tytul { get; set; } = string.Empty;

        public string? Opis { get; set; }

        public ZadanieStatus Status { get; set; } = ZadanieStatus.DoZrobienia;
        public int Priorytet { get; set; } = 1;

        public DateOnly? TerminRealizacji { get; set; }

        public int ProjektId { get; set; }
        public Projekt Projekt { get; set; } = null!;

        public int? PracownikId { get; set; }
        public Pracownik? Pracownik { get; set; }
    }
}