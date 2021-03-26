using System;

namespace ContoCorrenteLib
{
    public abstract class Operazione
    {
        public DateTime DataOperazione { get; protected set; }
        public string Descrizione { get; protected set; }
        public decimal Importo { get; protected set; }

        public Operazione(decimal importo, string descrizione)
        {
            this.DataOperazione = DateTime.Now;
            this.Importo = importo;
            this.Descrizione = descrizione;
        }

        public override string ToString() => "Operazione: " + this.Importo + "€ il " + this.DataOperazione + "\n\t" + this.Descrizione;

    }
}