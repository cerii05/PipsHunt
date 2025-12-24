using UnityEngine;
using UnityEngine.SceneManagement; // Penting untuk perpindahan scene

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Tarik Panel_Pause ke sini di Inspector
    private bool isPaused = false;

    void Start()
    {
        // Pastikan panel mati saat game dimulai
        if (pausePanel != null) pausePanel.SetActive(false);
        
        // Memastikan waktu berjalan normal saat start
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Fitur tambahan: Tekan Esc di keyboard untuk Pause/Resume
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
        Time.timeScale = 0f; // Menghentikan seluruh gerakan fisika & waktu
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        Time.timeScale = 1f; // Mengembalikan waktu ke normal
        isPaused = false;
    }

    // FUNGSI BARU UNTUK TOMBOL HOME
    public void GoToMenu()
    {
        Time.timeScale = 1f; // WAJIB: Kembalikan waktu ke normal sebelum pindah scene
        SceneManager.LoadScene("MenuScene"); // Pastikan nama scene sesuai
    }
}