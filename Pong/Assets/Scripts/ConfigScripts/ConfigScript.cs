using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class ConfigScript : MonoBehaviour
{
    public string menuScene;
    public AudioMixer audioMixer;
    public Text ballRespawnTimeText;

    private void Start()
    {
        ballRespawnTimeText.text = PlayerPrefs.GetInt("TimeBetweenRounds", 3).ToString();
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void IncreaseTimeBtwRounds()
    {
        int actualTime = PlayerPrefs.GetInt("TimeBetweenRounds", 3);

        if(actualTime < 10)
        {
            int newTime = actualTime + 1;
            PlayerPrefs.SetInt("TimeBetweenRounds", newTime);
            ballRespawnTimeText.text = newTime.ToString();
        }
    }

    public void DecreaseTimeBtwRounds()
    {
        int actualTime = PlayerPrefs.GetInt("TimeBetweenRounds", 3);

        if (actualTime > 0)
        {
            int newTime = actualTime - 1;
            PlayerPrefs.SetInt("TimeBetweenRounds", newTime);
            ballRespawnTimeText.text = newTime.ToString();
        }
    }
}
