using System;

namespace ContoCorrenteLib
{
    public abstract class Operazione
    {
        public DateTime DataOperazione { get; set; }
        public abstract string Descrizione { get; set; }
        public abstract decimal Importo { get; set; }

    }
}