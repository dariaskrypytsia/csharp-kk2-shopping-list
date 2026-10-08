## Felrapport

### Fel 1: Programmet kraschade vid start
- **Vad hände:**  Programmet kraschade direkt vid start med `IndexOutOfRangeException`.
- **Varför:** Det fanns en tom rad sist i filen. `Split` gjorde en tom del av den raden, och då fanns inte `parts[1]`. Namnen hade också ett osynligt tecken, `\r`, i slutet. Då syntes inte namnen i listan och sökningen hittade inget.
- **Lösning:** Jag hoppar över tomma rader med `continue` och tar bort `\r` med `Trim()`.

### Fel 2: Programmet kraschade när jag skrev bokstäver
- **Vad hände:** Programmet kraschade när jag skrev bokstäver i stället för siffror. Felet hette `FormatException`.
- **Varför:** `int.Parse` kan inte göra om bokstäver till ett tal.
- **Lösning:** Jag använder `int.TryParse` i stället. Om det blir fel skriver programmet ett meddelande och går tillbaka till menyn.

### Fel 3: Totalen blev fel
- **Vad hände:** Totalen visade 121 kr i stället för 136 kr. Programmet kraschade inte, men svaret var fel.
- **Varför:** Loopen i `Total` började på index 1. Listan börjar på index 0, så den första varan räknades aldrig med.
- **Lösning:** Jag ändrade loopen så att den börjar på index 0.


### Fel 4: Programmet kraschade när jag tog bort ett nummer som inte finns
- **Vad hände:** Programmet kraschade när jag skrev till exempel 0 eller 7 och listan hade tre varor. Felet hette `ArgumentOutOfRangeException`.
- **Varför:** `RemoveAt` försökte ta bort en plats som inte finns i listan.
- **Lösning:** Jag använder `try` och `catch (ArgumentOutOfRangeException)`. Metoden returnerar `false` om numret är fel, och `Program.cs` skriver ett felmeddelande.

### Fel 5: Programmet sa att listan var sparad fast det blev fel
- **Vad hände:** Programmet skrev "Listan är sparad" även när filen inte gick att spara. Man fick inget felmeddelande.
- **Varför:** `catch` var tom, så felet försvann. Meddelandet stod efter `try`-blocket, så det skrevs alltid.
- **Lösning:** Jag flyttade meddelandet in i `try`. Jag fångar `UnauthorizedAccessException` och `IOException` och skriver ett felmeddelande.

### Fel 6: Programmet kraschade när items.txt saknades
- **Vad hände:** Programmet kraschade när filen inte fanns. Felet hette `FileNotFoundException`. Det kraschade också om en rad i filen var fel, till exempel `abc;Test` eller en rad utan `;`.
- **Varför:** Programmet försökte läsa en fil som inte fanns. `parts[1]` finns inte om raden saknar `;`, och `int.Parse` kan inte göra om `abc` till ett tal.
- **Lösning:** Jag använder `try` och `catch (FileNotFoundException)`, så programmet startar med en tom lista. Jag använder `if (parts.Length < 2)` för att kontrollera att raden har två delar. Jag använder `if (!int.TryParse(...))` för att kontrollera att priset är ett tal. Om en rad är fel skriver programmet ett meddelande och hoppar över raden med `continue`.

## Designval

När en vara blir för dyr för budgeten returnerar `Add` `false`. Om varan får plats lägger `Add` till den och returnerar `true`.

Jag valde `false` och inte ett undantag. Jag tycker att det är lättare. Det är inget fel i programmet när budgeten tar slut. Det kan hända när man handlar. `Program.cs` behöver bara veta ja eller nej, och då räcker en `if`.

I `Program.cs` skriver jag `if (!list.Add(item))`. Om svaret är `false` skriver programmet ett meddelande. Sedan fortsätter programmet.

`Item` är annorlunda. Där kastar jag ett undantag om namnet är tomt eller priset är negativt. En sådan vara ska aldrig finnas. `Program.cs` fångar undantaget och skriver ett meddelande.
