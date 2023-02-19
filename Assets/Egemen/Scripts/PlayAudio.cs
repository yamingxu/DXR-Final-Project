using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource reverseTime, clockSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioSource(int i)
    {
        if (i == 0)
        {
            clockSound.Play();
        } else if (i == 1)
        {
            clockSound.volume = clockSound.volume / 3;
            reverseTime.Play();
        }
    }
}
