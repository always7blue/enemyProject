using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Can miktar�
    public int currentHealth;
    public Image healthBar;


    void Start()
    {
        
      currentHealth = maxHealth;
      UpdateHealthBar();

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("D��man " + damage + " hasar yedi.");
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth; // Sa�l�k y�zdesine g�re doluluk
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
