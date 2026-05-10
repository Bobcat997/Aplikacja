using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Klient zewnętrzny firmy (firma lub osoba prywatna).
    /// </summary>
    public class Klient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NazwaFirmy { get; set; } = string.Empty;

        public string? ImieKontakt { get; set; }
        public string? NazwiskoKontakt { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? Telefon { get; set; }

        public ICollection<Projekt> Projekty { get; set; } = new List<Projekt>();
    }
}