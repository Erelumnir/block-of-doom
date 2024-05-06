using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   void OnCollisionEnter2D(Collision2D collision)
    {
        //GameManager.Instance.HandleBallCollision(GetComponent<Rigidbody2D>());
    }
}
