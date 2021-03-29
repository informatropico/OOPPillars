using System;
using System.Collections.Generic;

namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta il generico Conto Corrente.
    //
    public abstract class ContoCorrente
    {
        //
        //  Soglia sotto la quale non sono più permesse operazioni di prelievo.
        //
        private decimal _soglia;
        
        //
        //  IBAN del conto corrente.
        //
        public IBAN IBAN { get; protected set; }
        
        //
        //  Elenco delle operazione eseguite dal momento dell'apertura del conto.
        //
        public ICollection<Operazione> ElencoOperazioni { get; protected set; }
        
        //
        //  Elenco degli intestatari del conto.
        //
        public ICollection<Intestatario> Intestatari {get; protected set;}
        
        //
        //  Saldo del conto corrente.
        //
        public virtual decimal Saldo 
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
        }

        //
        //  Creazione di un nuovo conto corrente (catena dei costruttori).
        //
        public ContoCorrente(ICollection<Intestatario> intestatari, decimal soglia) : this(intestatari, soglia, 0.00M)
        {}

        //
        //  Creazione di un nuovo conto corrente.
        //
        public ContoCorrente(ICollection<Intestatario> intestatari, decimal soglia, decimal importoIniziale)
        {
            this.IBAN = new IBAN();
            this.ElencoOperazioni = new List<Operazione>();
            this.Intestatari = intestatari;
            this._soglia = soglia;
            if(importoIniziale>0.00M)
            {
                this.Deposita(importoIniziale, "Apertura conto.");
            }          
        }

        //
        //  Operazione di Prelievo.
        //  L'operazione è concessa solo se il Saldo, al netto del prelievo, è ancora maggiore della soglia.
        //
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

        //
        //  Operazione di Deposito.
        //  L'operazione produce un effetto solo nel caso in cui l'importo da depositare sia positivo.
        //
        public virtual void Deposita(decimal importoDaDepositare, string descrizione)
        {
            ElencoOperazioni.Add(new Deposito(
                importo: importoDaDepositare,
                descrizione: descrizione));
        }

        //
        //  Restituisce l'elenco di tutte le operazioni eseguite sul conto corrente
        //
        public string ReportOperazioni()
        {
            string saldo = "Saldo:" + this.Saldo + "€ aggiornato al " + DateTime.Now.ToString() + "\n";
            string elencoOperazioni = "Elenco Operazioni:";
            if(this.ElencoOperazioni.Count == 0)
            {
                return "\nNessuna operazione registrata";
            }
            foreach (var operazione in this.ElencoOperazioni)
            {
                elencoOperazioni += "\n" + operazione.ToString();
            }
            return saldo + elencoOperazioni;
        }


    }
}