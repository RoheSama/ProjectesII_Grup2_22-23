using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternController : MonoBehaviour
{
    //Variables de Pins
    public GameObject[] pins;
    public Sprite pinClickedSprite;
    public Sprite pinSprite;
    GameObject lastPin;
    GameObject actualPin;
    private List<int> pinsOverlapped = new List<int>();
    
    // Variables de Patterns
    public PhoneDrawController phoneDrawController;
    public Pattern[] patterns; 
    public MouseCheck mouseCheck;
    public GameObject corruption;
    public GameObject soulEater;
  
    //Target
    public targetScript targetScript;
    
    //Update
    void Update()
    {
        if (phoneDrawController.isDrawing && mouseCheck.overlappedObject == true)
        {
            actualPin = mouseCheck.overlappedObject;
            if (actualPin != lastPin)
            {
                //Afegir els pins activats al'array en ordre
                for(int i = 0; i < pins.Length; i++)
                {
                    if (pins[i] == mouseCheck.overlappedObject)
                        pinsOverlapped.Add(i);
                    //Canviar de Sprite quan el pin est� activat
                    mouseCheck.overlappedObject.GetComponent<Image>().sprite = pinClickedSprite;
                }
            }
            lastPin = actualPin;
        }

        // Si no est�s dibuixant
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
    // Comprovar si has fet el pattern correcte
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

    // Efectes de la maledicci�o Corruption
    void Corruption()
    {
        Debug.Log("corruption");
        if (targetScript.Target != null)
        {
            Debug.Log("Destroy");
            Destroy(targetScript.Target);
            targetScript.ClearTarget();
        }
    }

    // Efectes de la maledicci�o Soul Eater
    void SoulEater()
    {
        soulEater.SetActive(true);
    }
}


