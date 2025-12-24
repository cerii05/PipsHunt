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
    public GameObject victoryPanel; 
    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateScoreUI(); 
        if (victoryPanel != null) victoryPanel.SetActive(false); 
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

    public void ShowVictoryScreen()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    public void ResetGameAndGoHome()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("SavedLevel", 1); 
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