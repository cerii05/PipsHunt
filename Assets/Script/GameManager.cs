using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Settings")]
    public int totalItemsToWin = 3; 
    private int currentItems = 0;
    
    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;
    public GameObject victoryPanel; // Tarik Panel Kemenangan Level 3 ke sini

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateScoreUI(); 
        if (victoryPanel != null) victoryPanel.SetActive(false); // Pastikan panel mati saat mulai
    }

    public void CollectItem()
    {
        currentItems++; 
        UpdateScoreUI();

        if (currentItems >= totalItemsToWin)
        {
            Debug.Log("SEMUA ITEM TERKUMPUL! Sekarang kembali ke Spawn Point.");
        }
    }

    // Fungsi untuk memunculkan Panel Menang (Dipanggil dari FinishPoint)
    public void ShowVictoryScreen()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan game agar player tidak bisa gerak
        }
    }

    // Fungsi untuk tombol "Home" di Victory Panel (Mulai ulang dari level 1)
    public void ResetGameAndGoHome()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("SavedLevel", 1); // Reset progress ke level 1
        PlayerPrefs.Save();
        SceneManager.LoadScene("MenuScene");
    }

    public bool AllItemsCollected()
    {
        return currentItems >= totalItemsToWin;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentItems + "/" + totalItemsToWin;
        }
    }
}