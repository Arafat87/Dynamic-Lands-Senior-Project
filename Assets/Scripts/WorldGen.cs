using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public List<GameObject> worldGen = new List<GameObject>();
    public static WorldGen instance;
    public string biome;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    

    public void startGen(Vector3 spawnPosition)
    {
        int xPos = (int)spawnPosition.x;
        int yPos = (int)spawnPosition.y;
        int zPos = (int)spawnPosition.z;
        if (Round.instance.getRound() <= 5)
        { 
            if (Round.instance.getRound() == 1)
            {
                int ran = Random.Range(0, 7);
                GameObject firstSpawn = worldGen[ran];
                Instantiate(firstSpawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
                biome = "Plains";
            }
            else if (Round.instance.getRound() == 4)
            {
                int ran = Random.Range(8, 15);
                GameObject specialSpawn = worldGen[ran];
                Instantiate(specialSpawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
                biome = "Ice";
            }
            else
            {
                int ran = Random.Range(0, 15);
                GameObject spawn = worldGen[ran];
                Instantiate(spawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
                if(ran <= 7)
                {
                    biome = "Plains";
                }
                else
                {
                    biome = "Ice";
                }

            }
        }
        else if (Round.instance.getRound() > 5 && Round.instance.getRound() <= 15)
        {
            if (Round.instance.getRound() == 8)
            {
                int ran = Random.Range(16, 23);
                GameObject specialSpawn = worldGen[ran];
                Instantiate(specialSpawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
                biome = "Valley";
            }
            else
            {
                int ran = Random.Range(0, 23);
                GameObject spawn = worldGen[ran];
                Instantiate(spawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
                if (ran <= 7)
                {
                    biome = "Plains";
                }
                else if (ran > 7 && ran <= 15)
                {
                    biome = "Ice";
                }
                else
                {
                    biome = "Valley";
                }
            }
            
        }
        else if (Round.instance.getRound() > 15)
        {
            int ran = Random.Range(0, 26);
            GameObject spawn = worldGen[ran];
            Instantiate(spawn, new Vector3(xPos, yPos + 0.9f, zPos), Quaternion.identity);
            if (ran <= 7)
            {
                biome = "Plains";
            }
            else if (ran > 7 && ran <= 15)
            {
                biome = "Ice";
            }
            else if (ran > 15 && ran <= 23)
            {
                biome = "Valley";
            }
            else if (ran > 23 && ran <= 26)
            {
                biome = "Voids";
            }
        }
    }



}
