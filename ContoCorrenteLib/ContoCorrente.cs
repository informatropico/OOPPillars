using System.Collections.Generic;

namespace ContoCorrenteLib
{
    public abstract class ContoCorrenteLib
    {
        public IBAN IBAN { get; protected set; }
        public ICollection<Operazione> ElencoOperazioni { get; set; }
    }
}