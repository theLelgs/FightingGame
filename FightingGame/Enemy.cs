using System;

namespace FightingGame;

public class Enemy
{
    public int HP;
    public int minHit;
    public int maxHit;
    public int hitChance;
    public string name;
    public int Attack(int maxHit, int minHit, int hitChance)
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
}
