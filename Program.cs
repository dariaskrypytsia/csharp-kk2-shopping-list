ShoppingList list = new ShoppingList("items.txt", 455);
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    int choice;
    if (!Int32.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("\tFel! Välj motsvarande siffra!");
        continue;
    }

    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");
        int price;
        if (!Int32.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("\tFel! Ange ett tal!");
            continue;
        }
        list.Add(new Item(name, price));
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number;
        if (!Int32.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("\tFel! Ange ett tal!");
            continue;
        }
        if (list.RemoveAt(number))
        {
            Console.WriteLine("\tFel! Det finns ingen vara med det numret.");
        }
        
    }

    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
