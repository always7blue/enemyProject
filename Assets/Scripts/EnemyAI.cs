using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // NavMeshAgent i�in gerekli

public class EnemyAI : MonoBehaviour
{
    public float aggroRadius = 5f;
    public Transform player;
    private NavMeshAgent agent;
    public bool isAggroed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�enine referans al
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
            }
            else
            {
                agent.SetDestination(player.position);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAggroed = true; // Oyuncu alg�land�, takip ba�las�n
        }
    }
}
