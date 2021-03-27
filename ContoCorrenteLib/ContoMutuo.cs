using System.Collections.Generic;

namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta un conto corrente associato ad un Mutuo.
    //
    public class ContoMutuo : ContoCorrente
    {
        //
        //  Rappresenta l'importo per cui è stato concesso il Mutuo.
        //
        private decimal _importoMutuo;
        
        //
        //  Rappresenta il Conto Corrente associato al Mutuo.
        //
        public ContoRisparmio ContoRisparmioAssociato { get; protected set; }
        
        //
        //  Rappresenta l'IBAN del conto corrente associato al Mutuo.
        //
        public IBAN IBANAssociato {get; protected set;}

        //
        //  Override del Saldo che tiene in considerazione l'importo del mutuo.
        //
        public override decimal Saldo 
        { 
            get
            {
                return this._importoMutuo + base.Saldo;
            } 
        }

        //
        //  Costruisce un Mutuo assoicato ad un conto corrente della stessa banca.
        //  La soglia è sempre a 0.00 (estinzione del mutuo).
        //
        public ContoMutuo(ICollection<Intestatario> intestatari, decimal importoMutuo, ContoRisparmio contoRisparmioAssociato): base(intestatari, 0.00M)
        {
            this._importoMutuo = -importoMutuo;
            this.ContoRisparmioAssociato = contoRisparmioAssociato;
            this.IBANAssociato = this.ContoRisparmioAssociato.IBAN;
        }

        //
        //  Costruisce un Mutuo associato ad un conto corrente di una banca diversa.
        //  La soglia è sempre a 0.00 (estinzione del mutuo).
        //
        public ContoMutuo(ICollection<Intestatario> intestatari, decimal importoMutuo, string IBANAssociato): base(intestatari, 0.00M)
        {
            this._importoMutuo = -importoMutuo;
            this.ContoRisparmioAssociato = null;

            //  TO-DO new IBAN(string) potrebbe lanciare eccezione.
            this.IBANAssociato = new IBAN(IBANAssociato);
        }
        
        //
        //  Effettua un Deposito in un Mutuo che concorre ad estinguere il debito.
        //
        public override void Deposita(decimal importoDaDepositare, string descrizione)
        {          
            //  Controlla se il mutuo è estinto (TO-DO l'esitnzione può essere gestita in modo diverso)
            if(this.Saldo < 0)
            {
                //  Se il Mutuo è associato ad un conto esterno 
                //  o se nel Conto Risparmio ci sono abbastanza soldi allora posso eseguire il deposito
                if (this.ContoRisparmioAssociato == null
                || (this.ContoRisparmioAssociato != null && this.ContoRisparmioAssociato.Saldo > importoDaDepositare))
                {
                    this.ContoRisparmioAssociato.Preleva(importoDaDepositare, "Rata mutuo");
                    base.Deposita(importoDaDepositare, "Incasso rata mutuo");                   
                }
                else
                {
                    throw new System.Exception("Saldo non sufficiente per pagare la rata");
                }
            }
            else
            {
                throw new System.Exception ("Mutuo Estinto");
            }
        }

        //
        //  Effettua un Prelievo da un Mutuo.
        //  Il metodo della classe base dovrebbe sempre lanciare eccezione 
        //  in quanto il Saldo non è sufficiente a coprire il prelievo.
        //
        public override void Preleva(decimal importoDaPrelevare, string descrizione)
        {
            //  Lancerà sempre eccezione.
            base.Preleva(importoDaPrelevare, descrizione);
        }
    }
}