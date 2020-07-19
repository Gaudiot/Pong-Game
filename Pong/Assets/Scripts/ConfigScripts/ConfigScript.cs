using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class ConfigScript : MonoBehaviour
{
    public string menuScene;
    public AudioMixer audioMixer;
    public Text ballRespawnTimeText;
    public Slider musicSlider;

    private void Start()
    {
        ballRespawnTimeText.text = PlayerPrefs.GetInt("TimeBetweenRounds", 3).ToString();
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);

    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(menuScene);
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

    public void ChangeMusicVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }
}
