//var npc = new NPC();
//var hero = new Hero();
using HardGroup;
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