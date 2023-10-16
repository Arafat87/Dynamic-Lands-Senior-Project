using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public int FireCount;
    public int DashCount;
    public int HealCount;
    public int HPCount;
    public int IceCount;
    public int LifeDrainCount;
    public int DamageCount;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public List<Loot> loots = new List<Loot>();

    public void Add(Loot loot)
    {
        loots.Add(loot);
        string name = loot.getName();
        if (name == "HP")
        {
            HPCount++;
        }
        else if (name == "Fire")
        {
            FireCount++;
        }
        else if (name == "Ice")
        {
            IceCount++;
        }
        else if (name == "Lifedrain")
        {
            LifeDrainCount++;
        }
        else if (name == "Heal")
        {
            HealCount++;
        }
        else if (name == "Dash")
        {
            DashCount++;
        }
        else if (name == "Damage")
        {
            DamageCount++;
        }
    }

}
