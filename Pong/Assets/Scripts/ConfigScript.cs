using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ConfigScript : MonoBehaviour
{
    public string menuScene;
    public AudioMixer audioMixer;

    public void GoToTitle()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }
}
