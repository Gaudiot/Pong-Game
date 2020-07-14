using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float maxVelocityY;

    private Rigidbody2D ballRb;
    private Vector3 velocity;
    private float centerDirection;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector3(6, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ballRb.MovePosition(transform.position + (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        centerDirection = -transform.position.y / Mathf.Abs(transform.position.y);

        if (collision.CompareTag("Player"))
        {
            SoundScript.PlaySound("hitSound");
            var randomY = UnityEngine.Random.Range(maxVelocityY, -maxVelocityY);
            SetVelocity(-1, randomY);
        }
        else
        {
            SoundScript.PlaySound("hitSound");
            SetVelocity(1, Mathf.Abs(velocity.y)*(centerDirection));
        }
    }

    public void SetVelocity(float direction, float velocityY)
    {
        velocity.x *= direction;
        velocity.y = velocityY;
    }
}
