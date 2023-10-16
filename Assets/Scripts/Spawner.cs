using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Bear;
    public GameObject Bear2;
    public GameObject Bear3;
    public GameObject Bear4;
    public GameObject Bear5;

    public GameObject Penguin;
    public GameObject Penguin2;
    public GameObject Penguin3;
    public GameObject Penguin4;
    public GameObject Penguin5;

    public GameObject Zombie;
    public GameObject Zombie2;
    public GameObject Zombie3;
    public GameObject Zombie4;
    public GameObject Zombie5;

    public GameObject Alien;
    public GameObject Alien2;
    public GameObject Alien3;
    public GameObject Alien4;
    public GameObject Alien5;






    public static Spawner instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public List<Enemy> enemyList = new List<Enemy>();
  

    public string name;
    public string biome;

    
    Enemy spawnEnemy()
    {
        int difficulty = Round.instance.getDifficulty();
        List<Enemy> possibleEnemy = new List<Enemy>();


        foreach (Enemy enemy in enemyList)
        {
            if (difficulty >= enemy.getDifficulty() && biome == enemy.getBiome())
            {
                possibleEnemy.Add(enemy);
            }
        }
        Enemy tempEnemy = possibleEnemy[Random.Range(0, possibleEnemy.Count)];
        name = tempEnemy.getName();
        return tempEnemy;
    }

    public void InstantiateEnemy(Vector3 spawnPosition)
    {
        int xPos = Random.Range((int)spawnPosition.x - 5, (int)spawnPosition.x + 5);
        int yPos = (int)spawnPosition.y;
        int zPos = Random.Range((int)spawnPosition.z - 5, (int)spawnPosition.z + 5);
        Enemy createEnemy = spawnEnemy();

        if (createEnemy != null)
        {
            if(biome == "Plains")
            {
                if (name == "Bear")
                {
                    GameObject enemyObject = Instantiate(Bear, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Bear-2")
                {
                    GameObject enemyObject = Instantiate(Bear2, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Bear-3")
                {
                    GameObject enemyObject = Instantiate(Bear3, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Bear-4")
                {
                    GameObject enemyObject = Instantiate(Bear4, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Bear-5")
                {
                    GameObject enemyObject = Instantiate(Bear5, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
            }
            else if(biome == "Ice")
            {
                if (name == "Penguin")
                {
                    GameObject enemyObject = Instantiate(Penguin, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Penguin-2")
                {
                    GameObject enemyObject = Instantiate(Penguin2, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Penguin-3")
                {
                    GameObject enemyObject = Instantiate(Penguin3, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Penguin-4")
                {
                    GameObject enemyObject = Instantiate(Penguin4, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Penguin-5")
                {
                    GameObject enemyObject = Instantiate(Penguin5, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
            }
            else if (biome == "Valley")
            {
                if (name == "Zombie")
                {
                    GameObject enemyObject = Instantiate(Zombie, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Zombie-2")
                {
                    GameObject enemyObject = Instantiate(Zombie2, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Zombie-3")
                {
                    GameObject enemyObject = Instantiate(Zombie3, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Zombie-4")
                {
                    GameObject enemyObject = Instantiate(Zombie4, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Zombie-5")
                {
                    GameObject enemyObject = Instantiate(Zombie5, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
            }
            else if (biome == "Voids")
            {
                if (name == "Alien")
                {
                    GameObject enemyObject = Instantiate(Alien, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Alien-2")
                {
                    GameObject enemyObject = Instantiate(Alien2, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Alien-3")
                {
                    GameObject enemyObject = Instantiate(Alien3, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Alien-4")
                {
                    GameObject enemyObject = Instantiate(Alien4, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
                else if (name == "Alien-5")
                {
                    GameObject enemyObject = Instantiate(Alien5, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                }
            }
        }
    }
}