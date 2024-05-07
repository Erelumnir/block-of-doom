using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// This script handles most game events, like ball behaviour 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    GameObject ballObj;

    private int score;
    private int balls;

    public static GameManager Instance;

    [SerializeField]
    private Vector3 ballOrigin = new Vector3(0, -2, 0);
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LaunchBallAtStart();
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

        ballRB.velocity = dir * ball.initBallSpeed;
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

    public void LoseBall(int ballsLost)
    {
        balls -= ballsLost;
        DecreaseScore(25);
        UIManager.Instance.UpdateBallAmount(balls);
        Destroy(ballObj);
        LaunchBallAtStart();
    }
    public void LoseGame()
    {
        if (balls < 0)
        {
            UIManager.Instance.ShowLoseScreen();
        }
    }
    public void WinGame()
    {
        // Win Logic
    }
}