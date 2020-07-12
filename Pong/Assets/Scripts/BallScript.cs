using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float maxVelocityY;

    private float randomY;
    private Rigidbody2D ballRb;
    private Vector3 velocity;

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
        if (collision.CompareTag("Player"))
        {
            randomY = Random.Range(maxVelocityY, -maxVelocityY);
            SetVelocity(-1, randomY);
        }
        else
        {
            SetVelocity(1, -velocity.y);
        }
    }

    public void SetVelocity(float x, float y)
    {
        velocity.x *= x;
        velocity.y = y;
    }
}
