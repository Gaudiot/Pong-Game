using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnScript : MonoBehaviour
{
    public GameObject ball;
    public float timeBetweenRounds;
    public Transform[] spawnPoints;

    private float directionX;
    private float velocityY;
    private bool spawnBall = true;

    // Start is called before the first frame update
    void Start()
    {
        //will choose randomly to which direction the first ball should go;
        directionX = (Random.Range(0, 2) == 0) ? 1 : -1;

        timeBetweenRounds = PlayerPrefs.GetInt("TimeBetweenRounds", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnBall
            && GameObject.FindGameObjectWithTag("Ball") == null)
        {
            spawnBall = false;
            StartCoroutine(InstantiateBall());
        }
    }

    IEnumerator InstantiateBall()
    {
        yield return new WaitForSeconds(timeBetweenRounds);

        var randomLocation = Random.Range(0, spawnPoints.Length);
        var newBall = Instantiate(ball, spawnPoints[randomLocation]);
        spawnBall = true;

        yield return new WaitForEndOfFrame();

        newBall.GetComponent<BallScript>().SetVelocity(directionX, velocityY);
    }

    public void SetBallDirection(float newX, float newY)
    {
        directionX = newX;
        velocityY = newY;
    }
}
