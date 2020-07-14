using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip hitSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hitSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        if (sound == "hitSound")
        {
            audioSrc.PlayOneShot(hitSound);
        }
    }
}
