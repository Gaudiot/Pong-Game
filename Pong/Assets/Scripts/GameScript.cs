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

    private bool spawnBall = false;
    private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        force = (Random.Range(0, 2) == 0) ? Vector2.left : Vector2.right;
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

        if (!spawnBall
            && GameObject.FindGameObjectWithTag("Ball") == null)
        {
            spawnBall = true;
            StartCoroutine(InstantiateBall());
        }

    }

    IEnumerator InstantiateBall()
    {
        yield return new WaitForSeconds(secondsBtwRounds);

        var newBall = Instantiate(ball);

        yield return new WaitForEndOfFrame();

        newBall.GetComponent<BallScript>().PushBall(force, 300);

        spawnBall = false;
    }

    public void SetForce(Vector2 f)
    {
        force = f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene(menuScene);
    }
}
