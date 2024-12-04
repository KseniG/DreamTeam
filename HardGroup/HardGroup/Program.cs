using HardGroup;

public class Item
{
    public string Name { get; }
    public int Weight { get; } = 1; // Каждый предмет имеет вес 1

    public Item(string name)
    {
        Name = name;
    }
}

public class Inventory
{
    private List<Item> items = new List<Item>();
    public int Capacity { get; }
    public int CurrentWeight => items.Count; // Текущий вес инвентаря

    public Inventory(int capacity)
    {
        Capacity = capacity;
    }

    public bool AddItem(Item item)
    {
        if (CurrentWeight < Capacity)
        {
            items.Add(item);
            return true;
        }
        return false; // Не удалось добавить предмет, инвентарь полон
    }

    public bool RemoveItem(Item item)
    {
        return items.Remove(item);
    }

    public void CraftItem(string itemName, int requiredCount)
    {
        // Пример крафта: просто выводим информацию
        Console.WriteLine($"Для крафта {itemName} требуется {requiredCount} предметов.");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Инвентарь:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Name}");
        }
    }
}

public class Player
{
    public string Name { get; }
    public int Strength { get; }
    public Inventory Inventory { get; }

    public Player(string name, int strength, int inventoryCapacity)
    {
        Name = name;
        Strength = strength;
        Inventory = new Inventory(inventoryCapacity);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player("Игрок", 5, 10);

        // Создание предметов
        Item weapon = new Item("Оружие - w");
        Item elixir = new Item("Элексир - p");
        Item shield = new Item("Щит - sh");
        Item sword = new Item("Меч - sw");

        // Добавление предметов в инвентарь
        player.Inventory.AddItem(weapon);
        player.Inventory.AddItem(elixir);
        player.Inventory.AddItem(shield);
        player.Inventory.AddItem(sword);

        // Показать инвентарь
        player.Inventory.ShowInventory();

        // Пример крафта
        player.Inventory.CraftItem("Меч", 2);

        //var npc = new NPC();
        //var hero = new Hero();
        Console.WriteLine("Введите опцию диалога (1 или 2): ");
        int op = Convert.ToInt32(Console.ReadLine());
        DialogNode dialog = new DialogNode("Привет", 34, "rus");
        if (op == 1)
        {
            Console.WriteLine("P1: Привет!");
            Console.WriteLine("P2: Привет!");
        }
        else
        {
            Console.WriteLine("P1: Ты принёс предмет?");
            Console.WriteLine("P2: Нет...");
        }
    }
}

