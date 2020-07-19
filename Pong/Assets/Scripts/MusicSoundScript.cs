using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSoundScript : MonoBehaviour
{
    static AudioSource audioSrc;
    private static MusicSoundScript instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        if (instance == this) return;
        Destroy(gameObject);

    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {

        audioSrc.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
    }
}
