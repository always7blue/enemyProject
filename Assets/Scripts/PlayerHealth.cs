using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can
    private int currentHealth; // Mevcut can
    public Image playerHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Oyuncu ba�lang��ta tam canla ba�lar
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasar� mevcut candan d��
        if (currentHealth < 0) currentHealth = 0; // Can 0'�n alt�na d��mesin
        UpdateHealthBar();
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        // HealthBar'�n doluluk oran�n� ayarla (0 ile 1 aras�nda)
        playerHealth.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        // Oyuncu �ld���nde yap�lacak i�lemler
    }
}
