using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public float secondsBtwRounds = 3;
    public GameObject ball;
    public GameObject pausePanel;
    public string menuScene;

    private bool spawnBall = true;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        x = (Random.Range(0, 2) == 0) ? 1 : -1;
        y = (Random.Range(0, 2) == 0) ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            pausePanel.SetActive(!pausePanel.activeSelf);
            Time.timeScale = 1 - Time.timeScale;
        }

        if (spawnBall
            && GameObject.FindGameObjectWithTag("Ball") == null)
        {
            spawnBall = false;
            StartCoroutine(InstantiateBall());
        }

    }

    IEnumerator InstantiateBall()
    {
        yield return new WaitForSeconds(secondsBtwRounds);

        var newBall = Instantiate(ball);
        spawnBall = true;

        yield return new WaitForEndOfFrame();

        newBall.GetComponent<BallScript>().SetVelocity(x, y);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene(menuScene);
    }

    public void SetVelocityPercentage(float newX, float newY)
    {
        x = newX;
        y = newY;
    }
}
