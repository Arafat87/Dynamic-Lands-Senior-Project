using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
 
public class MoveToPosition : MonoBehaviour
{
    public Transform goal;
    GameObject player;
    public NavMeshAgent agent;
    public List<int> slowTick = new List<int>();
    private Animator anim;




    void Start()
    {
        player = GameObject.FindWithTag("Player");
        goal = player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 7f;
        anim = GetComponentInChildren<Animator>();


    }

    void Update()
    {
        agent.SetDestination(goal.position);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("collision detected");
            if (Inventory.instance.IceCount >= 1)
            {

                int tick = CharacterStats.instance.Ice;
                if (slowTick.Count <= 0)
                {
                    slowTick.Add(tick);
                    StartCoroutine(slowed());
                }
                else
                {
                    slowTick.Add(tick);
                }
            }

        }
    }

    IEnumerator slowed()
    {
    
        while (slowTick.Count > 0)
        {
            for (int i = 0; i < slowTick.Count; i++)
            {
                slowTick[i]--;
                agent.speed = 2f;
            }
            agent.speed = 7f;
            Debug.Log("slowing");
            slowTick.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1f);
        }
    }
}
