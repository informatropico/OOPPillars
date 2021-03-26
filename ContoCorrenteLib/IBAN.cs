namespace ContoCorrenteLib
{
    public class IBAN
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
            {

            } 
        }

        public IBAN()
        {
            this._numeroContoCorrente = _progressivoContoCorrente;
            _progressivoContoCorrente++;
        }
    }
    
}