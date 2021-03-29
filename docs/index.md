# OOPPillarsReview
## Scopo
Questo progetto l'ho pensato e modellato per ripassare e applicare i 4 pilastri fondamentali del paradigma di programmazione ad oggetti:
- Astrazione (Abstraction)
- Incapsulamento (Encapsulation)
- Ereditarietà (Inheritance)
- Polimorfismo (Polymorphism)

Il progetto è focalizzato principalmente su questi 4 aspetti e riprende in parte un esempio proposto da Microsoft in una delle sue guide ufficiali. Questo significa che molte questioni non sono state considerate o approfondite. Cercherò di citarle nel paragrafo dedicato all'analisi e allo sviluppo della soluzione.

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

In questa sezione viene presentata una breve analisi della solzuone che ho scelto di implementare.
Cercherò di mettere in relazione i quattro principi con le scelte che ho fatto (cercherò anche di evidenziare i punti mancanti e possibili migliorie).

### Definizione delle entità

Dall'analisi del testo ho individuato le seguenti entità e le seguenti relazioni:

#### Conto Corrente
Una classe astratta che rappresenta il concetto stesso al centro di questo esercio. La selta di renderla abstract dipende dal fatto che ai fini dell'esercizio istaniare un cocnto corrente non ha senso, ma hanno senso solo le sue specificazioni.

#### Conto Mutuo
Rappresenta un conto corrente nel quale è possibile effettuare solo depositi per estinguere il debito.

#### Conto Risparmio
Rappresenta un conto corrente e si differenzia dalla sua classe base in quanto deve mettere a disposizione dei report entrate-uscite (questo fatto giustifica la classe, altirmenti sarebbe identica alla classe base).

#### Operazione
Rappresenta la generica operazione sul conto corrente. Anche in questo caso la scelta è ricaduta su una classe astratta, in quanto l'istanza di una operazione ha senso solo per una delle due specificazioni (pensate per questo esercizio)

#### Deposito
Rappresenta una Operazione il cui importo deve essere positivo.

#### Prelievo
Rappresenta una Operazione il cui importo deve essere negativo.

#### Intestatario
Rappresenta l'intestatario del conto corrente (è una sorta di classe di servizio, per dare un senso di completezza all'esercizio).

#### IBAN
Rappresenta il codice identificativo del conto corrente. In questo caso sono state fatte numerose semplificazioni: gli IBAN gestiti sono solo italiani, non ci sono controlli sulla correttenza dei dati (in particolare del numero del conto corrente). Anche in questo caso serve a dare un po' un senso di completezza all'esercizio.

### Diagramma delle relazioni

![alt text](img/OOPPillars.jpg "Schema concettuale della soluzione")

### Descrizione della soluzione
