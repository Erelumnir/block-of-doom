using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles most game events, like ball behaviour 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    public float initBallSpeed = 1f; // Initial speed
    public float addBallSpeed = 0.1f; // Incremental speed increase

    public static GameManager Instance;

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
    }
    void Start()
    {
        LaunchBallAtStart();
    }

    void LaunchBallAtStart()
    {
        // Instantiate a new ball object and get the RigidBody
        GameObject ballObj = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody2D ballRB = ballObj.GetComponent<Rigidbody2D>();

        // Calculate the initial direction and set velocity
        float angle = Random.Range(-45f, 45f);
        Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;

        ballRB.velocity = dir * initBallSpeed;
    }

    public void HandleBallCollision(Rigidbody2D ballRB)
    {
        // Increase ball speed slightly upon collision
        ballRB.velocity += ballRB.velocity.normalized * addBallSpeed;
    }
}