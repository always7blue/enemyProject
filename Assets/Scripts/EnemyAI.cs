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
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�eni
        animator = GetComponent<Animator>(); // Animator bile�eni
    }

    void Update()
    {
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

    public void OnDeath()
    {
        // D��man �ld���nde hareketi durdur

        Debug.Log("OnDeath Metodu �al��t�");
        
        agent.isStopped = true;
        

       
     
        if (animator != null)
        {
            Debug.Log("�l�m animasyonu tetiklendi.");
            animator.SetBool("isDead", true); // �l�m animasyonunu tetikle
            animator.SetBool("isWalking", false);
        }
    }
}
