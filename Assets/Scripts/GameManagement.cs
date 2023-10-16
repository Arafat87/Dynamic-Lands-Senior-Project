using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;

    public List<GameObject> spawners = new List<GameObject>();
    public List<GameObject> biomes = new List<GameObject>();
    public List<GameObject> spawnedBiomes = new List<GameObject>();
    public List<string> biomeNames = new List<string>();




    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (Round.instance.getRound() < 6)
            {
                Round.instance.setDifficulty(1);
            }
            else if (Round.instance.getRound() >= 6 && Round.instance.getRound() < 15)
            {
                Round.instance.setDifficulty(2);
            }
            else if (Round.instance.getRound() >= 15 && Round.instance.getRound() < 23)
            {
                Round.instance.setDifficulty(3);
            }
            else if (Round.instance.getRound() >= 23)
            {
                Round.instance.setDifficulty(4);
            }
            Gen();
            addGen();
            spawnedBiome();
            Add();
            Spawn();
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(Round.instance.getDifficulty());


        }


    }

    public void Update()
    {
        if(Round.instance.allAlive == 0 && CharacterStats.instance.currentHP > 0)
        {
            Round.instance.allAlive = 1;
            resetSpawn();
            resetGen();
            resetSpawnedBiome();
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;

        }
    }

    public void Gen()
    {
        foreach (GameObject biome in GameObject.FindGameObjectsWithTag("TempBiome"))
        {
            biomes.Add(biome);
            biome.GetComponent<MeshCollider>().enabled = false;
            biome.GetComponent<MeshRenderer>().enabled = false;

        }

    }

    public void addGen()
    {
        foreach (GameObject biome in biomes)
        {
            WorldGen.instance.startGen(biome.transform.position);
            biomeNames.Add(WorldGen.instance.biome);
        }

    }

    public void resetGen()
    {
        foreach (GameObject biome in GameObject.FindGameObjectsWithTag("TempBiome"))
        {
            biome.GetComponent<MeshCollider>().enabled = true;
            biome.GetComponent<MeshRenderer>().enabled = true;

        }
        biomes.Clear();
        biomeNames.Clear();

    }
    public void Add()
    {
        foreach(GameObject spawn in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(spawn);
        }
    }

    public void Spawn()
    {
        for(int i = 0; i < spawners.Count; i++)
        {
            GameObject spawn = spawners[i];
            Spawner.instance.biome = biomeNames[i];
            Spawner.instance.InstantiateEnemy(spawn.transform.position);

            Round.instance.increaseEnemy();

        }
    }

    public void resetSpawn()
    {
        spawners.Clear();
    }

    public void spawnedBiome()
    {
        foreach (GameObject biome in GameObject.FindGameObjectsWithTag("Biome"))
        {
            spawnedBiomes.Add(biome);

        }
    }

    public void resetSpawnedBiome()
    {
        foreach (GameObject biome in spawnedBiomes)
        {
            Destroy(biome);


        }
        spawnedBiomes.Clear();
    }

}
