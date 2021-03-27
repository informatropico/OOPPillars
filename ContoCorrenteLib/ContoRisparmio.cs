using System.Collections.Generic;

namespace ContoCorrenteLib
{
    //
    //  Rappresenta un conto corrente classico
    //
    public class ContoRisparmio : ContoCorrente
    {
        public ContoRisparmio(ICollection<Intestatario> intestatari, decimal soglia) : base(intestatari, soglia) 
        {

        }
        public override void Deposita(decimal importoDaDepositare, string descrizione) => base.Deposita(importoDaDepositare, descrizione);

        public override void Preleva(decimal importoDaPrelevare, string descrizione) => base.Preleva(importoDaPrelevare, descrizione);
    }
}