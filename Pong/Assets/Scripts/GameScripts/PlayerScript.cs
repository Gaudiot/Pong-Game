using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode up, down;
    public float moveSpeed = 1;

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

    private void FixedUpdate()
    {
        playerRb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
