using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aggroRadius = 5f;
    public Transform player;
    public int health = 100; // Can miktar�
    private NavMeshAgent agent;
    private Animator animator;
    public bool isAggroed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�eni
        animator = GetComponent<Animator>();  // Animator bile�eni
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
            return; // �l�yse di�er i�lemler yap�lmaz.
        }

        if (isAggroed)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > aggroRadius * 2) // D��man �ok uzakla�t���nda takip b�rakabilir
            {
                isAggroed = false;
                agent.ResetPath();
                animator.SetBool("isWalking", false); // Y�r�meyi durdur
            }
            else
            {
                agent.SetDestination(player.position);
                animator.SetBool("isWalking", true); // Y�r�me animasyonu ba�lat
            }
        }
        else
        {
            animator.SetBool("isWalking", false); // Y�r�meyi durdur
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAggroed = true; // Oyuncu alg�land�, takip ba�las�n
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
        animator.SetBool("isDead", true); // �l�m animasyonunu tetikle
        agent.isStopped = true; // D��man hareketi durdur
        Destroy(gameObject, 3f); // 3 saniye sonra d��man� yok et
    }
}
