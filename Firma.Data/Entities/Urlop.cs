using Firma.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Entities
{
    /// <summary>
    /// Urlop lub nieobecność pracownika.
    /// </summary>
    public class Urlop
    {
        public int Id { get; set; }

        public DateOnly DataOd { get; set; }
        public DateOnly DataDo { get; set; }

        public UrlopTyp Typ { get; set; }
        public string? Uwagi { get; set; }

        public int PracownikId { get; set; }
        public Pracownik Pracownik { get; set; } = null!;
    }
}