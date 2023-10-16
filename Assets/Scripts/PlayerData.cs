using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData

{


    public int damage;
    public int playerDamage;
    public int damageIncrease;
    public int maxHP;
    public int maxHPIncrease;

    public int Dash;
    public int DashIncrease;
    public int Fire;
    public int FireIncrease;
    public int Heal;
    public int Ice;
    public int IceIncrease;
    public int LifeDrainDamage;
    public int LifeDrain;
    public int LifeDrainIncrease;
    public int currentHP;
    public int round;

    public PlayerData(CharacterStats character)
    {
        playerDamage = CharacterStats.instance.damage;
        maxHP = CharacterStats.instance.maxHP;
        Dash = CharacterStats.instance.Dash;
        Fire = CharacterStats.instance.Fire;
        Ice = CharacterStats.instance.Ice;
        LifeDrain = CharacterStats.instance.LifeDrain;
        currentHP = CharacterStats.instance.currentHP;
        round = Round.instance.round;
    }
}
