using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can
    private int currentHealth; // Mevcut can
    public Image playerHealth;
    public GameObject diePanel;
    public float delayBeforeMainMenu = 3f; // Ana men�ye ge�meden �nceki bekleme s�resi (saniye)

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

        diePanel.SetActive(true);
        StartCoroutine(WaitAndLoadMainMenu());

    }

    private IEnumerator WaitAndLoadMainMenu()
    {
        yield return new WaitForSeconds(delayBeforeMainMenu); // Belirtilen s�re kadar bekler
        SceneManager.LoadScene(0); // Ana men� sahnesini y�kler
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
