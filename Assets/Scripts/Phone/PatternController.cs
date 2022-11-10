using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternController : MonoBehaviour
{
    public Pattern[] patterns;
    public GameObject[] pins;
    public Sprite pinClickedSprite;
    public Sprite pinSprite;
    public PhoneDrawController phoneDrawController;
    public MouseCheck mouseCheck;

    public AudioClip pinSound;
    public AudioClip deathSound;
    AudioSource audioSource;
    public AudioSource deathAudioSource;

    //Target
    public targetScript targetScript;

    GameObject lastPin;
    GameObject actualPin;
    public GameObject corruption;
    public GameObject soulEater;
    private List<int> pinsOverlapped = new List<int>();
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //deathAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (phoneDrawController.isDrawing && mouseCheck.overlappedObject == true)
        {
            actualPin = mouseCheck.overlappedObject;
            if (actualPin != lastPin)
            {
                for(int i = 0; i < pins.Length; i++)
                {
                    if (pins[i] == mouseCheck.overlappedObject)
                        pinsOverlapped.Add(i);
                    mouseCheck.overlappedObject.GetComponent<Image>().sprite = pinClickedSprite;
                    audioSource.PlayOneShot(pinSound, 0.1f);
                }
            }
            lastPin = actualPin;
        }

        else if(phoneDrawController.isDrawing==false)
        {
            if (pinsOverlapped.Count > 0)
            {
                CheckIfPatternDrawn();
                pinsOverlapped.Clear();
                for(int i = 0; i < pins.Length; i++)
                {
                     pins[i].GetComponent<Image>().sprite = pinSprite;
                }
            }
        }      
    }
    void CheckIfPatternDrawn()
    {
        bool patternFound = false;
        for (int i = 0; i < patterns.Length && !patternFound; i++)
        {
            if (patterns[i].sequence.Length != pinsOverlapped.Count)
                continue;

            bool correctSequence = true;
            for (int j = 0; j < patterns[i].sequence.Length; j++)
            {
                correctSequence &= patterns[i].sequence[j] == pinsOverlapped[j];
            }
            if (correctSequence)
            {
                patternFound = true;
                SendMessage(patterns[i].functionCall, this);
            }
        }
    }
    void Corruption()
    {
        Debug.Log("corruption");
        corruption.SetActive(true);
        if (targetScript.Target != null)
        {
            Debug.Log("Destroy");
            Destroy(targetScript.Target);
            targetScript.ClearTarget();
            deathAudioSource.PlayOneShot(deathSound, 1f);
        }
    }
    void SoulEater()
    {
        soulEater.SetActive(true);
    }
}


