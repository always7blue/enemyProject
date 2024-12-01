using UnityEngine;

public class EnemyHandDamage : MonoBehaviour
{
    public int damageAmount = 10; // Verilecek hasar miktar�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncunun tag'ini kontrol et
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // PlayerHealth scriptini al
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Hasar uygula
            }
        }
    }
}
