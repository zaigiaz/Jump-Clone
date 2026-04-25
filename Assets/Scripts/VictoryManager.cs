using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.Instance.FullReset();
    }
}