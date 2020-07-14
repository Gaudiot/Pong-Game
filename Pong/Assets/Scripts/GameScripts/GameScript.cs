using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject pausePanel;
    public string menuScene;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene(menuScene);
    }
}
