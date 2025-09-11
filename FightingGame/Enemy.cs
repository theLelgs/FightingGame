using System;
namespace FightingGame;

public class Character
{
    public int HP;
    public int minHit;
    public int maxHit;
    public int hitChance;
    public int critChance;
    public string name;
    public int Attack(int minHit, int maxHit, int hitChance)
    {
        if (Random.Shared.Next(1, 100) <= hitChance)
        {
            return Random.Shared.Next(minHit, maxHit + 1);
        }
        else
        {
            return 0;
        }
    }
    public int HeavyAttack(int minHit, int maxHit, int hitChance)
    {
        if (Random.Shared.Next(1, 100) <= hitChance / 2)
        {
            return Random.Shared.Next(minHit, maxHit + 1) * 2;
        }
        else
        {
            return 0;
        }
    }
    
}
