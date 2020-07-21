using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode up, down;
    public float moveSpeed = 1;
    public bool isBot = false;

    private bool ballInScene = false;
    private Rigidbody2D playerRb;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBot)
        {
            if (ballInScene)
            {
                var ballYPosition = GameObject.FindGameObjectWithTag("Ball").transform.position.y;

                if (ballYPosition > transform.position.y + 0.5f)
                {
                    direction = Vector3.up;
                }
                else if (ballYPosition < transform.position.y - 0.5f)
                {
                    direction = Vector3.down;
                }
                else
                {
                    direction = Vector3.zero;
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.y) >= 0.3f)
                {
                    direction = (transform.position.y > 0) ? Vector3.down : Vector3.up;
                }
                else
                {
                    direction = Vector3.zero;
                }
            }
        }
        else
        {
            if (Input.GetKey(up))
            {
                direction = Vector3.up;
            }
            else if (Input.GetKey(down))
            {
                direction = Vector3.down;
            }
            else
            {
                direction = Vector3.zero;
            }
        }
        
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void SetBallInScene(bool isBallInScene)
    {
        ballInScene = isBallInScene;
    }
}
