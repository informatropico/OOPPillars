using System.Collections.Generic;
using System.Linq;

namespace ContoCorrenteLib
{
    //
    //  Rappresenta un conto corrente classico
    //
    public class ContoRisparmio : ContoCorrente
    {
        public ContoRisparmio(ICollection<Intestatario> intestatari, decimal soglia, decimal importoIniziale) : base(intestatari, soglia, importoIniziale) 
        {}
        
        public override void Deposita(decimal importoDaDepositare, string descrizione) => base.Deposita(importoDaDepositare, descrizione);

        public override void Preleva(decimal importoDaPrelevare, string descrizione) => base.Preleva(importoDaPrelevare, descrizione);

        //
        //  Report Entrate-Uscite dall'apertura del conto.
        //
        public string ReportEntrateUscite()
        {
            return ReportEntrateUscite(this.ElencoOperazioni.ToList());
        }

        //
        //  Report Entrate-Uscite per il mese specificato.
        //
        public string ReportEntrateUscite(int mese)
        {
            var operazioni = this.ElencoOperazioni.Where(op => op.DataOperazione.Month == mese).ToList();
            return ReportEntrateUscite(operazioni);
        }

        //
        //  Costruzione del report.
        //
        private string ReportEntrateUscite(List<Operazione> operazioni)
        {
            string entrate = "Entrate:\n";
            string uscite = "Uscite:\n";

            decimal saldoEntrate = 0.00M;
            decimal saldoUscite = 0.00M;

            if(operazioni.Count == 0)
            {
                return "Nessun report da visualizzare";
            }
            foreach (var operazione in operazioni)
            {
                if(operazione.Importo < 0)
                {
                    uscite += operazione.ToString() + "\n";
                    saldoUscite += operazione.Importo; 
                }
                else
                {
                    entrate += operazione.ToString() + "\n";
                    saldoEntrate += operazione.Importo;
                }
            }

            if(entrate == "Entrate:\n")
            {
                entrate += "Nessun movimento in entrata\nSaldo: " + saldoEntrate;
            }
            else
            {
                entrate += "\n\nSaldo: " + saldoEntrate;
            }

            if(uscite == "Uscite:\n")
            {
                uscite += "Nessun movimento in uscita\nSaldo: " + saldoUscite;
            }
            else
            {
                uscite += "\n\nSaldo: " + saldoUscite;
            }

            return "REPORT ENTRATE-USCITE\n" + entrate + "\n" + uscite;

        }
    }
}