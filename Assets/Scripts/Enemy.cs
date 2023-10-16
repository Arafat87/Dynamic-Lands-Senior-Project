using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public string enemyBiome;
    public int difficulty;

    public Enemy(string enemyName, int difficulty, string enemyBiome)
    {
        this.enemyName = enemyName;
        this.difficulty = difficulty;
        this.enemyBiome = enemyBiome;
    }

    public string getName()
    {
        return this.enemyName;

    }

    public string getBiome()
    {
        return this.enemyBiome;
    }

    public int getDifficulty()
    {
        return this.difficulty;

    }

    public int changeRound(int difficulty)
    {
        this.difficulty = difficulty;
        return difficulty;
    }
}
