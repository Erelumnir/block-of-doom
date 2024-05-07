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

    public void ToggleLoseScreen()
    {
        loseScreen.SetActive(!loseScreen.activeSelf);
    }

    public void ToggleWinScreen()
    {
        winScreen.SetActive(!winScreen.activeSelf);
    }

    public void RetryLevel()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ToggleLoseScreen();
    }

    public void LoadMainMenu()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    } 
}
