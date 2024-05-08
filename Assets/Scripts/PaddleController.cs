using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handle paddle logic

public class PaddleController : MonoBehaviour
{
    // Vars
    [SerializeField]
    public float paddleSpeed = 0.75f; // Default Speed Value: 0.75f

    [SerializeField]
    Collider2D leftWall;
    [SerializeField]
    Collider2D rightWall;

    private float leftBoundary;
    private float rightBoundary;

    public float paddleWidth;

    void Start()
    {
        // Calculate the boundaries based on wall positions and paddle size
        paddleWidth = GetComponent<Collider2D>().bounds.size.x;
        leftBoundary = leftWall.transform.position.x + leftWall.bounds.size.x / 2 + paddleWidth / 2;
        rightBoundary = rightWall.transform.position.x - rightWall.bounds.size.x / 2 - paddleWidth / 2;
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);
        float clampedX = Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    public float reflectionFactor = 2.0f; 

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