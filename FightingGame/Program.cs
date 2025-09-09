using FightingGame;
Enemy e1 = new() {hitChance = 50, minHit = 1, maxHit = 4, HP = 30, name="Bob"};
Enemy e2 = new() {hitChance = 75, minHit = 2, maxHit = 3, HP = 20, name = "David" };
Enemy p1 = new() {hitChance = 50, minHit = 1, maxHit = 6, HP = 20, name = Console.ReadLine() };

static void Print(string a, int time)
{
    for (int i = 0; i < a.Length; i++)
    {
        Console.Write(a[i]);
        Thread.Sleep(time / a.Length);
        if (Console.KeyAvailable == true)
        {
            if (Console.ReadKey(true).KeyChar == ' ')
            {
                time = 0;
            }
        }
    }
    Console.Write("\n\n");
}
static int Attack(int minHit, int maxHit, int hitChance)
{
    if (Random.Shared.Next(1, 100) <= hitChance)
    {
        return Random.Shared.Next(minHit, maxHit+1);
    }
    else
    {
        return 0;
    }
}
int playerHP = 20;
int enemyHP = 20;
int playerHitChance = 50;
int enemyHitChance = 50;
Print("What is your name?", 30);
string playerName = Console.ReadLine();
List<string> EnemyNames = ["Bob", "David", "Dumstrut"];
string enemyName = EnemyNames[Random.Shared.Next(0,3)];
while (playerHP > 0 && enemyHP > 0)
{
    enemyHP -= Attack(1, 6, playerHitChance);
    playerHP -= Attack(1, 6, enemyHitChance);
    Print($"{enemyName}'s HP is {enemyHP}",150);
    Print($"{playerName}'s HP is {playerHP}",150);
    Console.ReadLine();
}
if (enemyHP <= 0 && playerHP >= 0)
{
    Print($"You, {playerName}, won!", 300);
}
else if (enemyHP >= 0 && playerHP <= 0)
{
    Print($"The enemy, {enemyName}, won!", 300);
}
else
{
    Print("It's a draw!", 300);
}
Console.ReadLine();