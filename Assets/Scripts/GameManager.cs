using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLevelIndex = 0;
    public int lives = 2;
    public int[] levelSceneIndices = { 1, 2, 3 };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        lives--;
        
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            ReloadCurrentLevel();
        }
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(levelSceneIndices[currentLevelIndex]);
    }

    public void LevelComplete()
    {
        currentLevelIndex++;
        
        if (currentLevelIndex >= levelSceneIndices.Length)
        {
            Victory();
        }
        else
        {
            SceneManager.LoadScene(levelSceneIndices[currentLevelIndex]);
        }
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
    }

    public void Victory()
    {
        UIManager.Instance.ShowVictory();
    }

    public void RestartGame()
    {
        currentLevelIndex = 0;
        lives = 2;
        SceneManager.LoadScene(levelSceneIndices[0]);
    }

    public void FullReset()
    {
        currentLevelIndex = 0;
        lives = 2;
        SceneManager.LoadScene(0);
    }
}
