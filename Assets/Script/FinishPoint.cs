using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance.AllItemsCollected())
            {
                CheckLevelStatus();
            }
        }
    }

    void CheckLevelStatus()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (currentSceneName == "level3")
        {
            GameManager.instance.ShowVictoryScreen();
        }
        else
        {
            MoveToNextLevel(currentSceneName);
        }
    }

    void MoveToNextLevel(string currentSceneName)
    {
        string levelNumberStr = currentSceneName.Replace("level", "");
        if (int.TryParse(levelNumberStr, out int currentLevel))
        {
            int nextLevel = currentLevel + 1;
            PlayerPrefs.SetInt("SavedLevel", nextLevel);
            PlayerPrefs.Save();
            SceneManager.LoadScene("level" + nextLevel);
        }
    }
}