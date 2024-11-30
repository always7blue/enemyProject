using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Bullet'ýn vereceði hasar miktarý

    private void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýlan obje "Enemy" tag'ine sahipse
        if (other.CompareTag("Enemy"))
        {
            // Enemy'deki Health script'ini al
            EnemyAI enemyHealth = other.GetComponent<EnemyAI>();
            if (enemyHealth != null)
            {
                // Hasar ver
                enemyHealth.TakeDamage(damage);
            }
            // Mermiyi yok et
            Destroy(gameObject);
        }
    }
}
