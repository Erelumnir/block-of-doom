using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballAmountText;
    public GameObject loseScreen;
    public GameObject winScreen;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateBallAmount(int balls)
    {
        ballAmountText.text = "Balls Left: " + balls.ToString();
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);  // Show the lose screen when the player dies
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);  // Show the lose screen when the player dies
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } 
}
