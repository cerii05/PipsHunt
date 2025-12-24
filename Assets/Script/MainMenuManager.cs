using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panel Settings")]
    public GameObject panelMenu;
    public GameObject panelGuide;

    // Kunci untuk database PlayerPrefs
    private string levelKey = "SavedLevel"; 

    void Start()
    {
        // Posisi awal: Menu aktif, Guide nonaktif
        if (panelMenu != null) panelMenu.SetActive(true);
        if (panelGuide != null) panelGuide.SetActive(false);
    }

    // Dipasang pada Play_Btn di Panel_Menu
    public void OpenGuide()
    {
        panelMenu.SetActive(false);
        panelGuide.SetActive(true);
    }

    // Dipasang pada Button Play di Panel_Guide
    public void StartGame()
    {
        // Mengambil progress, default ke 1 jika baru pertama main
        int progressLevel = PlayerPrefs.GetInt(levelKey, 1); 
        
        // Memuat scene sesuai nama persis: level1, level2, atau level3
        SceneManager.LoadScene("level" + progressLevel);
    }

    // Dipasang pada Exit_Btn
    public void QuitGame()
    {
        Debug.Log("Game Closing...");
        Application.Quit();
    }
}