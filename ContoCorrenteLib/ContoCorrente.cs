using System.Collections.Generic;

namespace ContoCorrenteLib
{
    public abstract class ContoCorrente
    {
        private decimal _soglia;
        public IBAN IBAN { get; protected set; }
        public ICollection<Operazione> ElencoOperazioni { get; protected set; }
        public ICollection<Intestatario> Intestatari {get; protected set;}
        public decimal Saldo 
        {
            get
            {
                var _saldo = 0.00M;
                foreach (var operazione in ElencoOperazioni)
                {
                    _saldo += operazione.Importo;
                }
                return _saldo;
            }

            protected set
            {}

        }

        public ContoCorrente(ICollection<Intestatario> intestatari, decimal soglia)
        {
            this.IBAN = new IBAN();
            this.ElencoOperazioni = new List<Operazione>();
            this.Intestatari = intestatari;
            this._soglia = soglia;
        }

        public virtual void Preleva(decimal importoDaPrelevare, string descrizione)
        {
            if(this.Saldo - importoDaPrelevare > this._soglia)
            {
                ElencoOperazioni.Add(new Prelievo(
                    importo: importoDaPrelevare,
                    descrizione: descrizione
                ));
            }
            else
            {
                throw new System.Exception("Operazione non concessa");
            }
        }

        public virtual void Deposita(decimal importoDaDepositare, string descrizione)
        {
            ElencoOperazioni.Add(new Deposito(
                importo: importoDaDepositare,
                descrizione: descrizione
            ));
        }

        public string ReportOperazioni()
        {
            string elencoOperazioni = "Elenco Operazioni:";
            if(this.ElencoOperazioni.Count == 0)
            {
                return "Nessuna operazione registrata";
            }
            foreach (var operazione in this.ElencoOperazioni)
            {
                elencoOperazioni += "\n" + operazione.ToString();
            }
            return elencoOperazioni;
        }


    }
}