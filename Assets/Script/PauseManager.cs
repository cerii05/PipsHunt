using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; 
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        if (pausePanel != null) pausePanel.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    // FUNGSI BARU UNTUK TOMBOL HOME
    public void GoToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MenuScene"); 
    }
}