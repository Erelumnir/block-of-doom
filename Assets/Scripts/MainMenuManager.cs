using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level_0");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
