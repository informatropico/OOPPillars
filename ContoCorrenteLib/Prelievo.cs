namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta un deposito.
    //  Il deposito è un'operazione caratterizzata da un importo negaativo.
    //
    public class Prelievo : Operazione
    {
        //
        //  Creazione di un Prelievo, memorizzando l'importo con un segnonegativo
        //
        public Prelievo(decimal importo, string descrizione) : base(-importo, descrizione)
        {}
    }
}