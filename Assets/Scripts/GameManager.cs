using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLevelIndex = 0;
    public int lives = 2;
    public string[] levelSceneNames = { "_Scene_0", "_Scene_1", "_Scene_2" };
    public string gameOverSceneName = "GameOver";
    public string victorySceneName = "Victory";

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
        SceneManager.LoadScene(levelSceneNames[currentLevelIndex]);
    }

    public void LevelComplete()
    {
        currentLevelIndex++;
        
        if (currentLevelIndex >= levelSceneNames.Length)
        {
            Victory();
        }
        else
        {
            SceneManager.LoadScene(levelSceneNames[currentLevelIndex]);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void Victory()
    {
        SceneManager.LoadScene(victorySceneName);
    }

    public void RestartGame()
    {
        currentLevelIndex = 0;
        lives = 2;
        SceneManager.LoadScene(levelSceneNames[0]);
    }

    public void FullReset()
    {
        currentLevelIndex = 0;
        lives = 2;
        SceneManager.LoadScene("_Scene_0");
    }
}
