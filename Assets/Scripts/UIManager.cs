using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI ballAmountText;
    public TextMeshProUGUI[] upgradeText;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject upgradeScreen;

    public PlayerUpgrades playerUpgrades;
    public GameConfig config;
   

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
        foreach (TextMeshProUGUI scoreText in scoreTexts)
        {
            scoreText.text = "Score: " + score.ToString();
        }
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

    public void ToggleUpgradeScreen()
    {
        upgradeScreen.SetActive(!upgradeScreen.activeSelf);
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

    public void LoadNextLevel(int levelIndex)
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(levelIndex);
    }

    public void UpgradePaddleWidth()
    {
        playerUpgrades.PurchaseUpgrade(UpgradeType.PaddleSizeIncrease);
        upgradeText[0].text = "Paddle Width: " + config.paddleWidth;
        Debug.Log(config.paddleWidth);
        config.ApplyUpgrades(playerUpgrades);
    }

    public void UpgradeBallSpeed()
    {
        playerUpgrades.PurchaseUpgrade(UpgradeType.BallSpeedIncrease);
        upgradeText[1].text = "Ball Speed: " + config.ballInitialSpeed;
        Debug.Log(config.ballInitialSpeed);
        config.ApplyUpgrades(playerUpgrades);
    }

    public void UpgradeAddBalls()
    {
        playerUpgrades.PurchaseUpgrade(UpgradeType.ExtraBalls);
        upgradeText[2].text = "Extra Balls: " + (config.ballSpawnAmount - 1);
        Debug.Log(config.ballSpawnAmount);
        config.ApplyUpgrades(playerUpgrades);
    }

    public void UpgradeScoreMultiplier()
    {
        playerUpgrades.PurchaseUpgrade(UpgradeType.ScoreMultiplier);
        upgradeText[3].text = "Score Multiplier: " + (1 + config.scoreMultiplier);
        Debug.Log(config.scoreMultiplier);
        config.ApplyUpgrades(playerUpgrades);
    }
}
