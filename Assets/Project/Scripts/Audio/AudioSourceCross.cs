using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceCross : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipFlip;
    public AudioClip audioClipAlerting;

    
    //Flip cross sound
    public void flipCross()
    {
        audioSource.clip = audioClipFlip;
        audioSource.Play();
    }

    //Active cross sound
    public void areaCross()
    {
        audioSource.clip = audioClipAlerting;
        audioSource.Play();
    }

    //Stop cross sound
    public void areaCrossOff()
    {
        audioSource.clip = audioClipAlerting;
        audioSource.Stop();
    }

    //Stop flip cross sound
    public void flipCrossOff()
    {
        audioSource.clip = audioClipFlip;
        audioSource.Stop();
    }
}
