# OOPPillarsReview
## Scopo
Questo progetto l'ho pensato e modellato per ripassare e applicare i 4 pilastri fondamentali del paradigma di programmazione ad oggetti:
- Astrazione (Abstraction)
- Incapsulamento (Encapsulation)
- Ereditarietà (Inheritance)
- Polimorfismo (Polymorphism)

Il progetto è focalizzato principalmente su questi 4 aspetti e riprende in parte un esempio proposto da Microsoft in una delel sui guide ufficiali.
Questo significa che molti aspetti non sono stati considerati o approfonditi. Cercherò di citarli nel paragrafo dedicato all'analisi e allo sviluppo della soluzione.

## Descrizione del problema
L'idea è quella di modellare un sistema che simuli la gestioen dei conti corrente di una banca.<br>  

La banca in questione gestisce due tipi di conto corrente:
- Conto Mutuo
- Conto Risparmio

Un Conto Mutuo rappresenta un debito che l’intestatario contrae con la Banca in questione.<br>
In un Conto Mutuo possono essere fatti solo depositi destinati ad estinguere il debito, mentre non sono permessi prelievi.<br>
Un Conto Mutuo può essere aperto collegandolo ad un Conto Risparmio oppure indicando un IBAN esterno (va ovviamente anche indicato l'miporto del mutuo).<br>

In un Conto Risparmio è possibile sia prelevare che depositare denaro.<br>
Un Conto Risparmio può essere creato con una somma iniziale o con saldo zero.<br>
Il deposito non ha limite.<br>
Il prelievo massimo dipende dal singolo conto corrente.<br>
Il prelievo è concesso se il Saldo del conto corrente dopo il prelievo non è inferiore ad una certa soglia.<br>

Per ogni Conto Risparmio devono essere messi a disposizione dei report periodici entrate/uscite e per ogni conto corrente deve essere possibile visualizzare la lista dei movimenti dal giorno dell’apertura.<br>

Ogni conto corrente è identificato da un codice IBAN univoco.<br>

## Analisi e sviluppo della soluzione
### Definizione delle entità
### Descrizione della soluzione
