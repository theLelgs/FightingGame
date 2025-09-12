using System;
namespace FightingGame;
public class Character
{
    public int HP;
    public int minHit;
    public int maxHit;
    public int hitChance;
    public int critChance;
    public int heavyAttackChance;
    public int critMult;
    public string name;
    public int Attack(int minHit, int maxHit, int hitChance, int critChance, int critMult)
    {
        int random = Random.Shared.Next(1, 100);
        if (random <= hitChance)
        {
            return Random.Shared.Next(minHit, maxHit + 1) * CriticalHitCheck(critChance, critMult);
        }
        else
        {
            return 0;
        }
    }
    public int HeavyAttack(int minHit, int maxHit, int hitChance, int critChance, int critMult)
    {
        if (Random.Shared.Next(1, 100) <= hitChance / 2)
        {
            return Random.Shared.Next(minHit, maxHit + 1) * 2*CriticalHitCheck(critChance, critMult);
        }
        else
        {
            return 0;
        }
    }

    public int CriticalHitCheck(int critChance, int critMult)
    {
        if (Random.Shared.Next(1, 101) <= critChance)
        {
            Console.WriteLine("Critical Hit!");
            return critMult;
        }
        else
        {
            return 1;
        }
    }
}