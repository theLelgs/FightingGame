using FightingGame;
Enemy e1 = new() {hitChance = 50, minHit = 1, maxHit = 4, HP = 30, name="Bob"};
Enemy e2 = new() {hitChance = 75, minHit = 2, maxHit = 3, HP = 20, name = "David" };
Enemy e3 = new() {hitChance = 50, minHit = 1, maxHit = 6, HP = 20, name = "John" };
int playerLevel = 1;
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
int enemyHitChance = 50;
int playerMinHit = 1 ;
int enemyMinHit = 1;
int enemyMaxHit = 6;
Print("What is your name?", 30);
string playerName = Console.ReadLine();
while (true)
{
int enemyHP = 20;
int playerHP = 20+3*(playerLevel-1);
int playerMaxHit = 6+(playerLevel-1);
int playerHitChance = 50+5*(playerLevel-1);
    List<string> EnemyNames = ["Bob", "David", "Dumstrut"];
    string enemyName = EnemyNames[Random.Shared.Next(0, 3)];
    while (playerHP > 0 && enemyHP > 0)
    {
        enemyHP -= Attack(playerMinHit, playerMaxHit, playerHitChance);
        playerHP -= Attack(enemyMinHit, enemyMaxHit, enemyHitChance);
        Print($"{enemyName}'s HP is {enemyHP}", 150);
        Print($"{playerName}'s HP is {playerHP}", 150);
        Console.ReadLine();
    }
    if (enemyHP <= 0 && playerHP >= 0)
    {
        Print($"You, {playerName}, won!", 300);
        playerLevel += 1;
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
}