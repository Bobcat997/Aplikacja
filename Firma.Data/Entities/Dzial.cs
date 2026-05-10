using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Dział / departament w strukturze firmy.
    /// </summary>
    public class Dzial
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Opis { get; set; }

        // Pracownicy należący do tego działu
        public ICollection<Pracownik> Pracownicy { get; set; } = new List<Pracownik>();
    }
}