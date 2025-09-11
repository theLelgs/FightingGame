using FightingGame;
Character e1 = new() {hitChance = 50, minHit = 1, maxHit = 4, HP = 30, critChance=0, heavyAttackChance=20,critMult=2 , name="Bob"};
Character e2 = new() {hitChance = 75, minHit = 2, maxHit = 3, HP = 20, critChance=0, heavyAttackChance=20,critMult=2 , name = "David"};
Character e3 = new() {hitChance = 50, minHit = 1, maxHit = 6, HP = 20, critChance=10, heavyAttackChance=20,critMult=2 , name = "John"};
Character p1 = new() {hitChance = 50, minHit = 1, maxHit = 6, HP = 20, critChance=0,critMult=2 , name = "" };
List<Character> list = [e1, e2, e3]; 
static string Keytest()
{
    string a = "0";
    while (a == "0")
    {
        if (Console.KeyAvailable)
        {
            a = Console.ReadKey(true).KeyChar.ToString();
        }
    }
    return a;
}
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
static (int, int) StatChange(int Cost, int BaseStat, int IncreaseAmount, int StatPoints, string StatName, Character p1)
{
    Print($"Do you want to increase {StatName}? +{IncreaseAmount} = {Cost} statpoint(s),you have {StatPoints} statpoints.\nYou have a {StatName} of {BaseStat}\n1. Increase {StatName}.\n2. Increase 5 times\n3. Use all stat points\n4. Cancel", 1000);
    string confirm = "";
    List<string> confirmlist = ["1", "2","3","4"];
    while (confirmlist.Contains(confirm) == false)
    {
        confirm = Keytest();
        if (StatName != "minimum hit")
        {
            if (confirm == "1" && StatPoints >= Cost)
            {
                Print($"Increased {StatName} by {IncreaseAmount}", 200);
                return (IncreaseAmount, Cost);
            }
            else if (confirm == "1" && StatPoints < Cost || confirm == "2" && StatPoints < Cost * 5)
            {
                Print("Not enough statpoints.", 100);
                return (0, 0);
            }
            else if (confirm == "2" && StatPoints >= 5 * Cost)
            {
                Print($"Increased {StatName} by {IncreaseAmount * 5}", 200);
                return (IncreaseAmount * 5, Cost * 5);
            }
            else if (confirm == "3")
            {
                int buyCount = StatPoints / Cost;
                Print($"Increased {StatName} by {buyCount * IncreaseAmount}", 200);
                return (IncreaseAmount * buyCount, Cost * buyCount);
            }
        }
        else
        {
            if (p1.minHit >= p1.maxHit)
            {
                Print("Minimum hit cannot be increased above the maximum hit", 200);
            }
            else if (confirm == "1" && StatPoints >= Cost)
            {
                Print($"Increased {StatName} by {IncreaseAmount}", 200);
                return (IncreaseAmount, Cost);
            }
            else if (confirm == "1" && StatPoints < Cost || confirm == "2" && StatPoints < Cost * 5)
            {
                Print("Not enough statpoints.", 100);
                return (0, 0);
            }
            else if (confirm == "2" && StatPoints >= 5 * Cost && p1.minHit <= p1.maxHit - 5)
            {
                Print($"Increased {StatName} by {IncreaseAmount * 5}", 200);
                return (IncreaseAmount * 5, Cost * 5);
            }
            else if (confirm == "2" && StatPoints>=5*Cost&&p1.maxHit>p1.minHit&&p1.minHit>p1.maxHit-5)
            {
                    Print($"Increased {StatName} by {p1.maxHit - p1.minHit}\nMinimum hit could not be increased past maximum hit", 300);
                    return (p1.maxHit - p1.minHit, Cost * (p1.maxHit - p1.minHit));
            }
            else if (confirm == "3")
            {
                int buyCount = StatPoints / Cost;
                if (p1.minHit <= p1.maxHit - buyCount)
                {
                    Print($"Increased {StatName} by {buyCount}", 200);
                    return (buyCount, Cost * buyCount);
                }
                else
                {
                    Print($"Increased {StatName} by {p1.maxHit - p1.minHit}\nMinimum hit could not be increased past maximum hit", 300);

                    return (p1.maxHit - p1.minHit, Cost * (p1.maxHit - p1.minHit));
                }
            }
            {

            }
        }
    }
    return (0, 0);
}
bool statsDone = false;
int statpoints = 30;
Print("What is your name?", 30);
p1.name= Console.ReadLine();
bool playing = true;
while (playing)
{
    Character e = list[Random.Shared.Next(list.Count)];
    Print($"Your enemy is {e.name}", 200);
    if (statpoints > 0)
    {
        statsDone = false;
        while (statsDone == false)
        {
            Print("What stat do you want to increase?\n1. Mininum Hit\n2. Maximum Hit\n3. Max HP\n4. Hit Chance\n5. Critical Hit Chance\n6. Skip stat boosts", 500);
            List<string> keylist = ["1", "2", "3", "4", "5", "6"];
            string key = "";
            while (keylist.Contains(key) == false)
            {
                key = Keytest();
                if (key == "1")
                {
                    (int a, int b) = StatChange(2, p1.minHit, 1, statpoints, "minimum hit", p1);
                    p1.minHit += a;
                    statpoints -= b;
                }
                if (key == "2")
                {
                    (int a, int b) = StatChange(2, p1.maxHit, 1, statpoints, "maximum hit", p1);
                    p1.maxHit += a;
                    statpoints -= b;
                }
                if (key == "3")
                {
                    (int a, int b) = StatChange(1, p1.HP, 4, statpoints, "maximum HP", p1);
                    p1.HP += a;
                    statpoints -= b;
                }
                if (key == "4")
                {
                    (int a, int b) = StatChange(1, p1.hitChance, 3, statpoints, "hit chance", p1);
                    p1.hitChance += a;
                    statpoints -= b;
                }
                if (key == "5")
                {
                    (int a, int b) = StatChange(1, p1.critChance, 4, statpoints, "critical hit chance", p1);
                    p1.critChance += a;
                    statpoints -= b;
                }
                if (key == "6" || statpoints == 0)
                {
                    statsDone = true;
                }
            }
        }
    }
    int enemyHP = e.HP;
    int playerHP = p1.HP;
    Print("Fight starts!", 150);
    while (playerHP > 0 && enemyHP > 0)
    {
        Print("What do you do?\n1. Normal attack\n2. Heavy attack", 150);
        string combatChoice = "";
        while (combatChoice != "1" && combatChoice != "2")
        {
            combatChoice = Keytest();
            if (combatChoice == "1")
            {
                int dmg = p1.Attack(p1.minHit, p1.maxHit, p1.hitChance, p1.critChance);
                if (dmg != 0)
                {
                    Print($"You dealt {dmg} damage to {e.name}.", 250);
                    enemyHP -= dmg;
                }
                else
                {
                    Print($"You missed your normal attack on {e.name}", 250);
                }
            }
            else if (combatChoice == "2")
            {
                int dmg = p1.HeavyAttack(p1.minHit, p1.maxHit, p1.hitChance, p1.critChance);
                enemyHP -= dmg;
                if (dmg != 0)
                {
                    Print($"You dealt {dmg} damage to {e.name} using the heavy attack!", 250);
                }
                else
                {
                    Print($"You missed your heavy attack on {e.name}", 250);
                }
            }
        }
        int enemyDMG;
        if (Random.Shared.Next(1, 101) <= e.heavyAttackChance)
        {
            enemyDMG = e.HeavyAttack(e.minHit, e.maxHit, e.hitChance, e.critChance);
            playerHP -= enemyDMG;
            Print($"{e.name} dealt {enemyDMG} damage to you using their heavy attack!", 100);
        }
        else
        {
            enemyDMG = e.Attack(e.minHit, e.maxHit, e.hitChance, e.critChance);
            playerHP -= enemyDMG;
            Print($"{e.name} dealt {enemyDMG} damage to you", 100);
        }
        Print($"{e.name}'s HP is {enemyHP}\n{p1.name}'s HP is {playerHP}", 150);
    }
    if (enemyHP <= 0 && playerHP >= 0)
    {
        Print($"You, {p1.name}, won!", 300);
    }
    else if (enemyHP >= 0 && playerHP <= 0)
    {
        Print($"The enemy, {e.name}, won!", 300);
    }
    else
    {
        Print("It's a draw!", 300);
    }
    Print("Play again?\n1. Yes\n2. No", 300);
    if (Keytest() != "1")
    {
        playing = false;
    }
    else
    {
        statpoints += 3;
        Print("You got 3 statpoints!", 100);
    }
}