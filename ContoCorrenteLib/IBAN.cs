namespace ContoCorrenteLib
{
    public sealed class IBAN
    {
        private static long _progressivoContoCorrente =  100000000001;
        private string _siglaInternazionale = "IT";
        private string _numeroDiControllo = "02";
        private string _CIN = "L";
        private string _ABI = "12345";
        private string _CAB = "00000";
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
            protected set
            {} 
        }

        public IBAN()
        {
            this._numeroContoCorrente = _progressivoContoCorrente;
            _progressivoContoCorrente++;
        }

        public IBAN(string codiceIBAN)
        {
            this._siglaInternazionale = codiceIBAN.Substring(0,2);
            this._numeroDiControllo = codiceIBAN.Substring(2,2);
            this._CIN = codiceIBAN.Substring(4,1);
            this._ABI = codiceIBAN.Substring(5,5);
            this._CAB = codiceIBAN.Substring(10,5);
            this._numeroContoCorrente = long.Parse(codiceIBAN.Substring(15));
        }
    }
    
}