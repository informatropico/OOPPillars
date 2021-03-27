using System;

namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta la generica operazione bancaria.
    //
    public abstract class Operazione
    {
        //
        //  Data dell'Operazione.
        //
        public DateTime DataOperazione { get; protected set; }
        
        //
        //  Descrizione dell'operazione.
        //
        public string Descrizione { get; protected set; }
        
        //
        //  Importo dell'operazione
        //
        public decimal Importo { get; protected set; }

        public Operazione(decimal importo, string descrizione)
        {
            this.DataOperazione = DateTime.Now;
            this.Importo = importo;
            this.Descrizione = descrizione;
        }

        //
        //  Override che descrive un'operazione
        //      "Operazione: XXX.YY€ il GG/MM/AAAA
        //          Descrizione testuale"
        //
        public override string ToString() => "Operazione: " + this.Importo + "€ il " + this.DataOperazione + "\n\t" + this.Descrizione;

    }
}