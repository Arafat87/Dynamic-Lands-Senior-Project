using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    public int HP = 100;

    public List<int> burnTick = new List<int>();
    public int damage;

    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

   
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.transform.CompareTag("Player") && PlayerMovement.instance.doDamage == true)
        {
            Debug.Log(PlayerMovement.instance.doDamage.ToString());
            HP = HP - CharacterStats.instance.playerDamage;
            Debug.Log("i can do damage");
            if (Inventory.instance.FireCount >= 1)
            {
                int tick = 5;
                if (burnTick.Count <= 0)
                {
                    burnTick.Add(tick);
                    StartCoroutine(burnDamage());
                }
                else
                {
                    burnTick.Add(tick);
                }

            }


        }
        if (HP <= 0)
        {
            Round.instance.decreaseEnemy();
            if (Round.instance.getEnemy() == 0)
            {
                Round.instance.changeStatus();
            }
            Debug.Log("enemy after decrease " + Round.instance.getEnemy());
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);

        }
        if (other.transform.CompareTag("Player"))
        {
            Attack();
        
        }
    }

    

    IEnumerator burnDamage()
    {
    while(burnTick.Count > 0)
        {
            for(int i = 0; i < burnTick.Count; i++)
            {
                burnTick[i]--;
            }
            HP = HP - CharacterStats.instance.Fire;
            burnTick.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(2f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }
}
