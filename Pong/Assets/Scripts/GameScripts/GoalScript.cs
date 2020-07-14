using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Text scoreUI;

    private int score = 0;
    private float opponentDirection;
    private BallSpawnScript ballSpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        ballSpawnScript = GameObject.Find("BallSpawner").GetComponent<BallSpawnScript>();
        opponentDirection = (transform.position.x / Mathf.Abs(transform.position.x));
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            score++;
            Destroy(collision.gameObject);

            ballSpawnScript.SetBallDirection(opponentDirection, 0);
        }
    }
}
