using Firma.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Sprzęt firmowy (laptop, telefon, monitor itp.).
    /// </summary>
    public class Sprzet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NumerSeryjny { get; set; }

        public SprzetStatus Status { get; set; } = SprzetStatus.Dostepny;

        public DateOnly DataZakupu { get; set; }
        public decimal Wartosc { get; set; }

        public int? PracownikId { get; set; }
        public Pracownik? Pracownik { get; set; }
    }
}