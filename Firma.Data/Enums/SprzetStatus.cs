namespace Firma.Data.Enums
{
    /// <summary>
    /// Status sprzętu firmowego
    /// </summary>
    public enum SprzetStatus
    {
        Dostepny,       // Wolny, można wydać
        WUzyciu,        // Wydany pracownikowi
        Serwis,         // W naprawie
        Zlokalizowany   // Inwentaryzacja / zagubiony
    }
}