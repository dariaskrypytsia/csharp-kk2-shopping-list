## Felrapport

### Fel 1: Programmet kraschade vid start
- **Programmet kraschade direkt vid start med `IndexOutOfRangeException`.**
- ** Det fanns en tom rad sist i filen. `Split` gjorde en tom del av den raden, och då fanns inte `parts[1]`. Namnen hade också ett osynligt tecken, `\r`, i slutet. Då syntes inte namnen i listan och sökningen hittade inget.:**
- **Jag hoppar över tomma rader med `continue` och tar bort `\r` med `Trim()`.** 

### Fel 2: ...


### Fel 3: 

### Fel 4: 

### Fel 5: 

### Fel 6

