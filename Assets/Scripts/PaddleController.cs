using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Vars
    public float paddleSpeed = .5f;

    private void Update()
    {
        float move = Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);
    }

    public float reflectionFactor = 2.0f; // This factor controls how much the hit position affects the bounce angle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject ball = collision.gameObject;
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

        // Calculate where the ball hit the paddle
        float hitPoint = collision.contacts[0].point.x - transform.position.x;
        float paddleWidth = GetComponent<BoxCollider2D>().size.x * transform.localScale.x;

        // Normalize the hit point to range -1 to 1
        float normalizedHitPoint = hitPoint / (paddleWidth / 2);

        // Adjust the ball's horizontal velocity based on where it hit the paddle
        float newVelocityX = normalizedHitPoint * reflectionFactor;
        Vector2 newVelocity = new Vector2(newVelocityX, 1).normalized * ballRb.velocity.magnitude;

        // Apply the new velocity to the ball
        ballRb.velocity = newVelocity;
    }
}