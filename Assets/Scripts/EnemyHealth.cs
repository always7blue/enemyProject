using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100; // Can miktar�
    private Animator animator;
    private EnemyAI enemyAI; // EnemyAI scriptine referans

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bile�eni
        enemyAI = GetComponent<EnemyAI>();   // EnemyAI scriptini al
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("D��man " + damage + " hasar yedi.");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true); // �l�m animasyonunu tetikle
        if (enemyAI != null)
        {
            enemyAI.OnDeath(); // EnemyAI'ye �l�m� bildir
        }
        Destroy(gameObject, 3f); // 3 saniye sonra d��man� yok et
    }
}
