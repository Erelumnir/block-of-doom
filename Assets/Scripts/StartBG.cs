using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBG : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    int amount = 10;

    GameObject ballObj;

    private Vector3 ballOrigin = new Vector3(0, -2, 0);

    private void Start()
    {
        LaunchBallAtStart();
    }
    void LaunchBallAtStart()
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        // Instantiate a new ball object and get the RigidBody
        ballObj = Instantiate(ballPrefab, ballOrigin, Quaternion.identity);
        Rigidbody2D ballRB = ballObj.GetComponent<Rigidbody2D>();
        Ball ball = ballObj.GetComponent<Ball>();

        // Calculate the initial direction and set velocity
        float angle = Random.Range(-360f, 360f);
        Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;

        ballRB.velocity = dir * ball.initBallSpeed;
    }
}
