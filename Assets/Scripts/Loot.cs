using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string lootName;
    public int dropChance;

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }

    public string getName()
    {
        return this.lootName;

    }

    public int getDrop()
    {
        return this.dropChance;

    }

    public int changeDrop(int drop)
    {
        this.dropChance = drop;
        return drop;
    }
}
