using System;

namespace ContoCorrenteLib
{
    //
    //  Classe che rappresenta un intestatario di un conto corrente
    //
    public class Intestatario
    {
        public static int _Id = 1;
        
        //
        //  Identificativo univoco
        //
        public int Id { get; protected set; }
        
        //
        //  Codice Fiscale dell'intestatario
        //
        public string CodiceFiscale { get; protected set; }
        
        //
        //  Nome dell'intestatario
        //
        public string Nome { get; protected set; }
        
        //
        //  Cognome dell'intestatario
        //
        public string Cognome { get; protected set; }
        
        //
        //  Data di nascita dell'intestatario
        //
        public DateTime DataDiNascita { get; protected set; }

        public Intestatario(string CF, string cognome, string nome)
        {
            this.Id = _Id;
            this.CodiceFiscale = CF;
            this.Cognome = cognome;
            this.Nome = nome;
            _Id++;

            // TO-DO
            // Ricavare data di nascita e popolare il campo
            // Verificare che l'intestatario si maggiorenne o lanciare eccezione
        }

        //
        //  Modifica i dati anagrafici di questo intestatario
        //
        public void ModificaIntestatario(string CF = null, string cognome = null, string nome = null)
        {
            if(CF != null)
            {
                this.CodiceFiscale = CF;
                // TO-DO
                // Ricalcolare la data dinascita e verificare la maggiore età prima della assegnazione
            }
            if(cognome != null)
            {
                this.Cognome = cognome;
            }
            if(nome != null)
            {
                this.Nome = nome;
            }
        }
        
    }
}