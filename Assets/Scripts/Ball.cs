using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameConfig config;

    float addBallSpeed;
    float maxBallSpeed;
    int ballDamage;

    private void Awake()
    {
        InitializeBall();
    }

    void InitializeBall()
    {
        addBallSpeed = config.ballSpeedIncrement;
        maxBallSpeed = config.ballMaxSpeed;
        ballDamage = config.ballDamage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 currVelocity = rb.velocity;

        // Check maxSpeed
        if (currVelocity.magnitude > maxBallSpeed) { return; }
        rb.velocity = currVelocity + (currVelocity.normalized * addBallSpeed);
        if (currVelocity.magnitude > maxBallSpeed) { rb.velocity = rb.velocity.normalized * maxBallSpeed; }

        Block block = collision.collider.GetComponent<Block>();
        if (block != null)
        {
            block.TakeDamage(ballDamage);
        }
    }
}
