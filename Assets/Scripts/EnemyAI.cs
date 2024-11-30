using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aggroRadius = 5f;
    public Transform player;
    public int health = 100; // Can miktarý
    private NavMeshAgent agent;
    private Animator animator;
    public bool isAggroed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþeni
        animator = GetComponent<Animator>();  // Animator bileþeni
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
            return; // Ölüyse diðer iþlemler yapýlmaz.
        }

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

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true); // Ölüm animasyonunu tetikle
        agent.isStopped = true; // Düþman hareketi durdur
        Destroy(gameObject, 3f); // 3 saniye sonra düþmaný yok et
    }
}
