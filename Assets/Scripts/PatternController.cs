using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public Pattern pattern;
    public GameObject[] pins;
    public PhoneDrawController phoneDrawController;
    public MouseCheck mouseCheck;

    GameObject lastPin;
    GameObject actualPin;
    int counter = 0;
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
                        pins[counter] = mouseCheck.overlappedObject;
                        counter++;
                    }
                    lastPin = actualPin;
            }
    }
}


