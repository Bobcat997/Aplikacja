using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Stanowisko służbowe w firmie (np. Programista, Kierownik, Księgowa).
    /// </summary>
    public class Stanowisko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; } = string.Empty;

        public decimal? PensjaMin { get; set; }
        public decimal? PensjaMax { get; set; }

        public ICollection<Pracownik> Pracownicy { get; set; } = new List<Pracownik>();
    }
}