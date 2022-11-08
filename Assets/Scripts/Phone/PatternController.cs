using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public Pattern[] patterns;
    public GameObject[] pins;
    public PhoneDrawController phoneDrawController;
    public MouseCheck mouseCheck;

    //Target
    public targetScript targetScript;


    GameObject lastPin;
    GameObject actualPin;
    public GameObject corruption;
    public GameObject soulEater;
    private List<int> pinsOverlapped = new List<int>();
    void Start()
    {
        
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
        }
    }
    void SoulEater()
    {
        soulEater.SetActive(true);
    }
}


