namespace ContoCorrenteLib
{
    public class Prelievo : Operazione
    {
        public Prelievo(decimal importo, string descrizione) : base(-importo, descrizione)
        {}
    }
}