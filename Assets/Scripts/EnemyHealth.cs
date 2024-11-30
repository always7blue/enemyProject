using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100; // Can miktarý
    private Animator animator;
    private EnemyAI enemyAI; // EnemyAI scriptine referans

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bileþeni
        enemyAI = GetComponent<EnemyAI>();   // EnemyAI scriptini al
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Düþman " + damage + " hasar yedi.");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isDead", true); // Ölüm animasyonunu tetikle
        }

        if (enemyAI != null)
        {
            enemyAI.OnDeath(); // EnemyAI'ye ölümü bildir
        }

        if (transform.parent != null)
        {
            Debug.Log("Parent objesi yok ediliyor: " + transform.parent.name);
            Destroy(transform.parent.gameObject, 3f); // Parent objeyi yok et
        }
        else
        {
            Debug.Log("Objesi yok ediliyor: " + gameObject.name);
            Destroy(gameObject, 3f); // Parent yoksa kendi objesini yok et
        }
    }
}
