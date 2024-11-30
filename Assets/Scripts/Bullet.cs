using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Bullet'�n verece�i hasar miktar�

    private void OnTriggerEnter(Collider other)
    {
       
        // E�er �arp�lan obje "Enemy" tag'ine sahipse
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("D��mana isabet etti.");
            // Enemy'deki Health script'ini al
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Hasar ver
                Debug.Log("D��mana hasar verdi.");
                enemyHealth.TakeDamage(damage);
            }
            // Mermiyi yok et
            Destroy(gameObject);
        }
    }
}
