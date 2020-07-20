using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float maxVelocityY;

    private Rigidbody2D ballRb;
    private Vector3 velocity;

    private void Awake()
    {
        velocity = new Vector3(6, 3, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ballRb.MovePosition(transform.position + (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var randomYVelocity = UnityEngine.Random.Range(maxVelocityY, -maxVelocityY);
            SetVelocity(-1, randomYVelocity);
        }
        else
        {
            var centerDirection = -transform.position.y / Mathf.Abs(transform.position.y);
            SetVelocity(1, Mathf.Abs(velocity.y)*(centerDirection));
        }

        SoundScript.PlaySound("hitSound");
    }

    public void SetVelocity(float direction, float velocityY)
    {
        velocity.x *= direction;
        velocity.y = velocityY;
    }
}
