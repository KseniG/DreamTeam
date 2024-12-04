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
        NPC npc1 = new NPC("Villager1");
        NPC npc2 = new NPC("Villager2");

        npc1.InteractWith(npc2);
        npc1.ChangeNeed("Hunger", -20);
        npc1.UpdateMood();

        Console.WriteLine($"{npc1.Name} Mood: {npc1.Mood}, Relationships: {npc1.Relationships[npc2.Name]}");
        Console.WriteLine($"{npc2.Name} Mood: {npc2.Mood}, Relationships: {npc2.Relationships[npc1.Name]}");
    }
}

public class NPC
{
    public string Name { get; set; }
    public Dictionary<string, int> Relationships { get; private set; }
    public int Mood { get; set; }
    public List<string> Schedule { get; private set; }
    public Dictionary<string, int> Needs { get; private set; }

    public NPC(string name)
    {
        Name = name;
        Relationships = new Dictionary<string, int>();
        Mood = 100;
        Schedule = new List<string>();
        Needs = new Dictionary<string, int>
        {
            { "Hunger", 100 },
            { "Thirst", 100 },
            { "Energy", 100 }
        };
    }

    public void ChangeRelationship(string otherNPC, int changeAmount)
    {
        if (Relationships.ContainsKey(otherNPC))
        {
            Relationships[otherNPC] += changeAmount;
        }
        else
        {
            Relationships[otherNPC] = changeAmount;
        }
    }

    public void UpdateMood()
    {

        if (Needs["Hunger"] < 50 || Needs["Thirst"] < 50)
        {
            Mood -= 10;
        }
        else
        {
            Mood += 5;
        }
    }

    public void AddToSchedule(string activity)
    {
        Schedule.Add(activity);
    }

    public void ChangeNeed(string need, int changeAmount)
    {
        if (Needs.ContainsKey(need))
        {
            Needs[need] = Math.Clamp(Needs[need] + changeAmount, 0, 100);
        }
    }

    public void InteractWith(NPC otherNPC)
    {

        ChangeRelationship(otherNPC.Name, 5);
        otherNPC.ChangeRelationship(Name, 5);
        UpdateMood();
        otherNPC.UpdateMood();
    }
}
