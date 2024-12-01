using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can
    private int currentHealth; // Mevcut can

    private void Start()
    {
        currentHealth = maxHealth; // Oyuncu baþlangýçta tam canla baþlar
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasarý mevcut candan düþ
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        // Oyuncu öldüðünde yapýlacak iþlemler
    }
}
