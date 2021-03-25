# OOPPillarsReview
## Descrizione
Pensiamo ad un esercizio per applicare i concetti fondamentali del paradigma di programmazione ad oggetti:
- Astrazione (Abstraction)
- Incapsulamento (Encapsulation)
- Ereditarietà (Inheritance)
- Polimorfismo (Polymorphism)

Per farlo utilizziamo come esempio quello di un programma per la gestione dei conti corrente di una ipotetica banca.<br>  

La banca in questione gestisce due tipi di conto corrente:
- Conto Mutuo
- Conto Risparmio

Un Conto Mutuo rappresenta un debito che l’intestatario contrae con la Banca in questione.<br>
In un Conto Mutuo possono essere fatti solo depositi destinati ad estinguere il debito, mentre non sono permessi prelievi.<br>
Un Conto Mutuo può essere aperto sia collegandolo ad un Conto Risparmio o indicando un IBAN esterno, oltre all’importo concesso a mutuo.

In un Conto Risparmio è possibile sia prelevare che depositare denaro.<br>
Un Conto Risparmio può essere creato con un somma iniziale o con saldo  zero.<br>
Il deposito non ha limite.<br>
Il prelievo massimo dipende dal singolo conto corrente.<br>
Il prelievo è concesso se il Saldo del conto corrente dopo il prelievo non è inferiore ad una certa soglia.<br>

Per ogni Conto Risparmio devono essere messi a disposizione dei report periodici entrate/uscite e per ogni conto corrente deve essere possibile visualizzare la lista dei movimenti dal giorno dell’apertura.<br>

Ogni conto corrente è identificato da un codice IBAN univoco.<br>
