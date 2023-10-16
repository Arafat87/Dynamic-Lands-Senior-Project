using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickup : MonoBehaviour
{

    public Loot loots;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.instance.Add(loots);
            Destroy(gameObject);
        }
    }
}
