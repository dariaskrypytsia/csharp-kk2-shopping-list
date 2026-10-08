## Felrapport

### Fel 1: Programmet kraschade vid start
- **Vad hände:**  Programmet kraschade direkt vid start med `IndexOutOfRangeException`.
- **Varför:** Det fanns en tom rad sist i filen. `Split` gjorde en tom del av den raden, och då fanns inte `parts[1]`. Namnen hade också ett osynligt tecken, `\r`, i slutet. Då syntes inte namnen i listan och sökningen hittade inget.:**
- **Lösning:** Jag hoppar över tomma rader med `continue` och tar bort `\r` med `Trim()`.

### Fel 2: Programmet kraschade när jag skrev bokstäver
- **Vad hände:** Programmet kraschade när jag skrev bokstäver i stället för siffror. Felet hette `FormatException`.
- **Varför:** `int.Parse` kan inte göra om bokstäver till ett tal.
- **Lösning:** Jag använder `int.TryParse` i stället. Om det blir fel skriver programmet ett meddelande och går tillbaka till menyn.

### Fel 3: Totalen blev fel
- **Vad hände:** Totalen visade 121 kr i stället för 136 kr. Programmet kraschade inte, men svaret var fel.
- **Varför:** Loopen i `Total` började på index 1. Listan börjar på index 0, så den första varan räknades aldrig med.
- **Lösning:** Jag ändrade loopen så att den börjar på index 0.

### Fel 3: 

### Fel 4: 

### Fel 5: 

### Fel 6

