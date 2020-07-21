using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public string gameScene;
    public string configScene;

    public GameObject mainPanel;
    public GameObject gameSelectPanel;

    public void StartGame()
    {
        mainPanel.SetActive(false);
        gameSelectPanel.SetActive(true);
    }

    public void BackToMainPanel()
    {
        mainPanel.SetActive(true);
        gameSelectPanel.SetActive(false);
    }

    public void LoadGame(bool againstAI)
    {
        GlobalData.VersusAI = againstAI;
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

    public void GoToSettings()
    {
        SceneManager.LoadScene(configScene);
    }
}
