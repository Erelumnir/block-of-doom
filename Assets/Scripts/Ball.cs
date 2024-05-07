using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initBallSpeed = 1f; // Initial speed
    public float addBallSpeed = 0.1f; // Incremental speed increase
    public float maxBallSpeed = 15f;
    public int ballDamage = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 currVelocity = rb.velocity;

        // Check maxSpeed
        if (currVelocity.magnitude > maxBallSpeed) { return; }
        rb.velocity = currVelocity + (currVelocity.normalized * addBallSpeed);
        if (currVelocity.magnitude > maxBallSpeed) { rb.velocity = rb.velocity.normalized * maxBallSpeed; }

        Debug.Log(currVelocity.magnitude);
        Debug.Log(collision.collider.name);

        Block block = collision.collider.GetComponent<Block>();
        if (block != null)
        {
            block.TakeDamage(ballDamage);
        }
    }
}
