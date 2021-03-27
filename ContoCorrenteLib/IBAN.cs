namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta il codice IBAN di un conto corrente.
    //  Il codice IBAN rappresentato è compatibile con l'IBAN dello stato italiano.
    //  Per gli scopi di questo esercizio è sufficiente (resta la possibilità di sviluppare
    //  un modello in grado di gestire IBAN di stati diversi).
    //
    public sealed class IBAN
    {
        private static long _progressivoContoCorrente =  100000000001;
        
        //
        //  Sigla internazionale (2 caratteri).
        //
        private string _siglaInternazionale = "IT";
        
        //
        //  Numero di controllo (2 caratteri).
        //
        private string _numeroDiControllo = "02";
        
        //
        //  CIN (1 carattere).
        //
        private string _CIN = "L";
        
        //
        //  ABI (5 caratteri).
        //
        private string _ABI = "12345";
        
        //
        //  CAB (5 caratteri).
        //
        private string _CAB = "00000";
        
        //
        //  Numero del conto corrente (12 caratteri).
        //
        private long _numeroContoCorrente;

        public string CodiceIBAN 
        { 
            get
            {
                return _siglaInternazionale 
                + _numeroDiControllo
                + _CIN
                + _ABI
                + _CAB
                + _numeroContoCorrente;
            } 
        }

        public IBAN()
        {
            this._numeroContoCorrente = _progressivoContoCorrente;
            _progressivoContoCorrente++;
        }

        //
        //  Costruzione di un codice IBAN direttamente da una stringa.
        //  Questo cotruttore è utile alla classe ContoMutuo per memorizzare
        //  il conto corrente associato al ContoMUtuo da cui prelevare la rata.
        //
        public IBAN(string codiceIBAN)
        {
            // TO-DO verificare che la stringa sia compatibile con un codice IBAN, altrimenti eccezione.

            //  Verifico che la lunghezza sia compatibile con un IBAN Italiano
            if(codiceIBAN.Length!= 27)
            {
                throw new System.Exception("Codice IBAN non valido. Accettati solo IBAN italiani (27 caratteri).");
            }

            this._siglaInternazionale = codiceIBAN.Substring(0,2);
            this._numeroDiControllo = codiceIBAN.Substring(2,2);
            this._CIN = codiceIBAN.Substring(4,1);
            this._ABI = codiceIBAN.Substring(5,5);
            this._CAB = codiceIBAN.Substring(10,5);
            this._numeroContoCorrente = long.Parse(codiceIBAN.Substring(15));
        }
    }
    
}