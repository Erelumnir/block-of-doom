using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles most game events, like ball behaviour 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    GameObject ballObj;

    int score;
    int lives;

    public int totalBlocks = 0;

    // int currentLevel = 1;

    public bool gameLost = false;
    public bool gameWon = false;
    bool paused = false;

    public static GameManager Instance;
    public GameConfig config;
    public PlayerUpgrades playerUpgrades;

    [SerializeField]
    private Vector3 ballOrigin = new Vector3(0, -2, 0);
    private void Awake()
    {
    Scene currScene = SceneManager.GetActiveScene();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else if (currScene.name == "MainMenu")
        {
            Destroy(gameObject);
            return;
        }
        config.ApplyUpgrades(playerUpgrades);
        InitializeGame();
    }

    void InitializeGame()
    {
        score = config.initialScore;    
        lives = config.initialLives;
    }
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        paused = false;
        Time.timeScale = 1;
        InitializeGame();
        LaunchBallAtStart();
    }

    private void Update()
    {
        if (lives < 0 && !gameLost)
        {
            LoseGame();
        }

        if (totalBlocks <= 0 && !gameWon)
        {
            WinGame();
        }

        // Escape Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ToggleLoseScreen();
            TogglePause();
        }
    }

    void LaunchBallAtStart()
    {
        // Instantiate a new ball object and get the RigidBody
        ballObj = Instantiate(ballPrefab, ballOrigin, Quaternion.identity);
        Rigidbody2D ballRB = ballObj.GetComponent<Rigidbody2D>();
        Ball ball = ballObj.GetComponent<Ball>();

        // Calculate the initial direction and set velocity
        float angle = Random.Range(-45f, 45f);
        Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;

        ballRB.velocity = dir * config.ballInitialSpeed;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UIManager.Instance.UpdateScore(score);
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        UIManager.Instance.UpdateScore(score);
    }

    public void LoseBall(int livesLost)
    {
        lives -= livesLost;
        DecreaseScore(25);
        UIManager.Instance.UpdateBallAmount(lives);
        Destroy(ballObj);
        LaunchBallAtStart();
    }

    public void LoseGame()
    {
        gameLost = true;
        TogglePause();
        UIManager.Instance.ToggleLoseScreen();
    }

    public void WinGame()
    {
        gameWon = true;
        TogglePause();
        UIManager.Instance.ToggleWinScreen();
    }

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
    }
}