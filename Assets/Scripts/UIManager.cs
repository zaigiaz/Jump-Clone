using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public Text livesText;

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

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void HideVictory()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);
    }

    public void RestartFromGameOver()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.FullReset();
    }

    public void RestartFromVictory()
    {
        victoryPanel.SetActive(false);
        GameManager.Instance.FullReset();
    }

    public void UpdateLivesDisplay(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}
