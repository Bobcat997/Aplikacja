namespace Firma.Data.Enums
{
    /// <summary>
    /// Status pojedynczego zadania
    /// </summary>
    public enum ZadanieStatus
    {
        DoZrobienia,    // Nowe zadanie
        WTrakcie,       // W realizacji
        Zakończone,     // Ukończone
        Zablokowane     // Zablokowane (np. czeka na kogoś)
    }
}