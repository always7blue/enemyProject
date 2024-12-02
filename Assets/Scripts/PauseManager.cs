using UnityEngine;
using UnityEngine.SceneManagement; // Main Menu i�in gerekli

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC tu�una bas�ld���nda
        {
            TogglePause(); // Oyunu duraklat veya devam ettir
        }
    }



    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // Oyun h�z�n� duraklat/d�zenle

        UnlockCursor();
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        LockCursor();
        Time.timeScale = 1; // Oyun devam eder

    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Oyun h�z� normale d�ner
        SceneManager.LoadScene(0); // Ana men� sahnesini y�kler
    }
}

