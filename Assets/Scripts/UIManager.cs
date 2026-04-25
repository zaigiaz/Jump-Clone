using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public TMP_Text livesText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        livesText = null;
        var texts = FindObjectsOfType<TMP_Text>();
        foreach (var t in texts)
        {
            if (t.name == "LivesText")
            {
                livesText = t;
                break;
            }
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
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        GameManager.Instance.FullReset();
    }

    public void RestartFromVictory()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);
        GameManager.Instance.FullReset();
    }

    public void UpdateLivesDisplay(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}