// Holds the items and takes care of loading and saving them.
using System.Linq.Expressions;

class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int budget;

    public ShoppingList(string path, int budget)
    {
        this.path = path;
        this.budget = budget; 
    }

    public bool Add(Item item)
    {
        if(Total() + item.Price > budget)
        {
            return false;
        }
        
        items.Add(item);
        return true;
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public bool RemoveAt(int number)
    {
        try
    {
        items.RemoveAt(number - 1);
        return true;
    }
    catch (ArgumentOutOfRangeException)
    {
        return false;
    }
    }


    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name.ToLower() == name.ToLower())
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
            Console.WriteLine("Listan är sparad.");
        }
        catch(UnauthorizedAccessException)
        {
            Console.WriteLine("Kunde inte spara: du saknar behörighet att skriva till filen.");
        }

        catch (IOException)
        {
            Console.WriteLine("Kunde inte spara: det gick inte att skriva till filen.");
        }

        
    }

    // Reads the file back into the list.
    public void Load()
    {
        string text;

        try
        {
            text=File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ingen sparad lista hittades. Startar med en tom lista.");
            return;
        }
        string[] lines = text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            string[] parts = line.Split(';');

            if (parts.Length < 2)
            {
                Console.WriteLine($"Hoppade över felaktig rad: {line}");
                continue;
            }
            if(!int.TryParse(parts[0], out int price))
            {
                Console.WriteLine($"Hoppade över felaktig rad: {line}");
                continue;
            }
            items.Add(new Item(parts[1].Trim(), price));

        }
    }
}
