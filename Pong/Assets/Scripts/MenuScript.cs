using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public string gameScene;
    public string configScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void GoToConfigs()
    {
        SceneManager.LoadScene(configScene);
    }
}
