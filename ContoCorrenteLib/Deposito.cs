namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta un deposito.
    //  Il deposito è un'operazione caratterizzata da un importo positivo.
    //       
    public class Deposito : Operazione
    {
        //
        //  Creazione di deposito
        //
        public Deposito(decimal importo, string descrizione) : base(importo, descrizione)
        {}
    }
}