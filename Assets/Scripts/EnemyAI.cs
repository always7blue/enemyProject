using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aggroRadius = 5f;
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public bool isAggroed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþeni
        animator = GetComponent<Animator>(); // Animator bileþeni
    }

    void Update()
    {
        if (isAggroed)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > aggroRadius * 2) // Düþman çok uzaklaþtýðýnda takip býrakabilir
            {
                isAggroed = false;
                agent.ResetPath();
                animator.SetBool("isWalking", false); // Yürümeyi durdur
            }
            else
            {
                agent.SetDestination(player.position);
                animator.SetBool("isWalking", true); // Yürüme animasyonu baþlat
            }
        }
        else
        {
            animator.SetBool("isWalking", false); // Yürümeyi durdur
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAggroed = true; // Oyuncu algýlandý, takip baþlasýn
        }
    }

    public void OnDeath()
    {
        // Düþman öldüðünde hareketi durdur

        Debug.Log("OnDeath Metodu çalýþtý");
        
        agent.isStopped = true;
        

       
     
        if (animator != null)
        {
            Debug.Log("Ölüm animasyonu tetiklendi.");
            animator.SetBool("isDead", true); // Ölüm animasyonunu tetikle
            animator.SetBool("isWalking", false);
        }
    }
}
