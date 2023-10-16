using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject HP;
    public GameObject Fire;
    public GameObject Ice;
    public GameObject LifeDrain;
    public GameObject Heal;
    public GameObject Dash;
    public GameObject Damage;




    public List<Loot> lootList = new List<Loot>();
    public string name;

    Loot getDroppedItem()
    {
        int randomNum = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in lootList)
        {
            if(randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            name = droppedItem.getName();
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = getDroppedItem();
        if (droppedItem != null)
        {
            if(name == "HP")
            {
                GameObject lootGameObject = Instantiate(HP, spawnPosition, Quaternion.identity);

            }
            else if (name == "Fire")
            {
                GameObject lootGameObject = Instantiate(Fire, spawnPosition, Quaternion.identity);

            }
            else if (name == "Ice")
            {
                GameObject lootGameObject = Instantiate(Ice, spawnPosition, Quaternion.identity);

            }
            else if (name == "LifeDrain")
            {
                GameObject lootGameObject = Instantiate(LifeDrain, spawnPosition, Quaternion.identity);

            }
            else if (name == "Heal")
            {
                GameObject lootGameObject = Instantiate(Heal, spawnPosition, Quaternion.identity);

            }
            else if (name == "Dash")
            {
                GameObject lootGameObject = Instantiate(Dash, spawnPosition, Quaternion.identity);

            }
            else if (name == "Damage")
            {
                GameObject lootGameObject = Instantiate(Damage, spawnPosition, Quaternion.identity);

            }
        }
    }


}
