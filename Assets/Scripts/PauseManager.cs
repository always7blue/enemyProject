using UnityEngine;
using UnityEngine.SceneManagement; // Main Menu için gerekli

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC tuþuna basýldýðýnda
        {
            TogglePause(); // Oyunu duraklat veya devam ettir
        }
    }



    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // Oyun hýzýný duraklat/düzenle

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
        Time.timeScale = 1; // Oyun hýzý normale döner
        SceneManager.LoadScene(0); // Ana menü sahnesini yükler
    }
}

