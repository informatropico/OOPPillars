using System.Collections.Generic;

namespace ContoCorrenteLib
{
    public class ContoMutuo : ContoCorrente
    {
        public ContoRisparmio ContoRisparmioAssociato { get; protected set; }
        public IBAN IBANAssociato {get; protected set;}

        public ContoMutuo(ICollection<Intestatario> intestatari, decimal importoMutuo, ContoRisparmio contoRisparmioAssociato): base(intestatari, 0.00M)
        {
            this.Saldo = importoMutuo;
            this.ContoRisparmioAssociato = contoRisparmioAssociato;
            this.IBANAssociato = this.ContoRisparmioAssociato.IBAN;
        }

        public ContoMutuo(ICollection<Intestatario> intestatari, decimal importoMutuo, string IBANAssociato): base(intestatari, 0.00M)
        {
            this.Saldo = importoMutuo;
            this.ContoRisparmioAssociato = null;
            this.IBANAssociato = new IBAN(IBANAssociato);
        }
        public override void Deposita(decimal importoDaDepositare, string descrizione)
        {          
            if(this.Saldo > 0)
            {
                if (this.ContoRisparmioAssociato == null
                || (this.ContoRisparmioAssociato != null && this.ContoRisparmioAssociato.Saldo > importoDaDepositare))
                {
                    this.ContoRisparmioAssociato.Preleva(importoDaDepositare, "Rata mutuo");
                    base.Deposita(-importoDaDepositare, "Incasso rata mutuo");                   
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

        public override void Preleva(decimal importoDaPrelevare, string descrizione)
        {
            throw new System.Exception ("Prelievo non concetito da un mutuo");
        }
    }
}