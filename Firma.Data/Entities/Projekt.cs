using Firma.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Projekt realizowany dla klienta.
    /// </summary>
    public class Projekt
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nazwa { get; set; } = string.Empty;

        public string? Opis { get; set; }

        public DateOnly DataRozpoczecia { get; set; }
        public DateOnly? DataZakonczenia { get; set; }

        public ProjektStatus Status { get; set; } = ProjektStatus.Planowany;

        public int KlientId { get; set; }
        public Klient Klient { get; set; } = null!;

        public ICollection<Zadanie> Zadania { get; set; } = new List<Zadanie>();
    }
}