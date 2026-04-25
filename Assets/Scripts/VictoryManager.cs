using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}