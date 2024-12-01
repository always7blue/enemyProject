using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100; // Can miktar�
 
    // EnemyAI scriptine referans

    void Start()
    {
        
      


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

        EnemyAI enemyAI = GetComponentInParent<EnemyAI>();


        if (enemyAI == null)
        {
            Debug.Log("EnemyAI'a ula��lam�yor" + gameObject.name);
        }

        if (enemyAI != null)
        {
            enemyAI.OnDeath(); // EnemyAI'ye �l�m� bildir
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
