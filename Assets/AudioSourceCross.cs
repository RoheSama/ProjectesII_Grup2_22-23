using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceCross : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipFlip;
    public AudioClip audioClipAlerting;

    
    public void flipCross()
    {
        audioSource.clip = audioClipFlip;
        audioSource.Play();
    }
    public void areaCross()
    {
        audioSource.clip = audioClipAlerting;
        audioSource.Play();
    }

    public void areaCrossOff()
    {
        audioSource.clip = audioClipAlerting;
        audioSource.Stop();
    }
    public void flipCrossOff()
    {
        audioSource.clip = audioClipFlip;
        audioSource.Stop();
    }
}
